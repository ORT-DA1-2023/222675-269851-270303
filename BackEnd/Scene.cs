using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Render3D.BackEnd
{
    public class Scene
    {
        private String _name;

        public Scene()
        {
            Camera = new Camera();
            RegisterDate = DateTimeProvider.Now;
            LastModificationDate = DateTimeProvider.Now;
            PositionedModels = new List<Model>();
        }


        public Client Client { get; set; }
        public Camera Camera { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                ValidateName(value);
                _name = value;
            }
        }

        public DateTime RegisterDate { get; }
        public DateTime LastModificationDate { get; private set; }
        public DateTime? LastRenderizationDate { get; set; }

        public List<Model> PositionedModels { get; set; }

        public Bitmap Preview { get; set; }

        public Vector3D ShootRay(Ray ray, int depth, Random random)
        {
            HitRecord3D hitRecord = null;
            double moduleMax = Math.Pow(10, 38);
            foreach (Model element in PositionedModels)
            {
                HitRecord3D hit = element.Figure.FigureHitRecord(ray, 0.001, moduleMax, (element.Material).Attenuation);
                if (hit != null)
                {
                    hitRecord = hit;
                    moduleMax = hit.Module;
                }
            }
            if (hitRecord != null)
            {
                if (depth > 0)
                {
                    //todo menos shoot ray puede ir en material
                    Vector3D newVectorPoint = hitRecord.Intersection.Add(hitRecord.Normal).Add(GetRandomInUnitSphere(random));
                    Vector3D newVector = newVectorPoint.Substract(hitRecord.Intersection);
                    Ray newRay = new Ray(hitRecord.Intersection, newVector);
                    Vector3D color = ShootRay(newRay, depth - 1, random);
                    Vector3D attenuation = hitRecord.Attenuation;
                    return new Vector3D(attenuation.X * color.X, attenuation.Y * color.Y, attenuation.Z * color.Z);
                }
                else
                {
                    return new Vector3D(0, 0, 0);
                }
            }
            else
            {
                return GetBlueSky(ray);
            }
        }

        private Vector3D GetBlueSky(Ray ray)
        {
            var vectorDirectionUnit = ray.Direction.GetUnit();
            var posY = 0.5 * (vectorDirectionUnit.Y + 1);
            var colorStart = new Vector3D(1, 1, 1);
            var colorEnd = new Vector3D(0.5, 0.7, 1.0);
            return colorStart.Multiply((1 - posY)).Add(colorEnd.Multiply(posY));
        }

        private Vector3D GetRandomInUnitSphere(Random random)
        {
            Vector3D vector;
            do
            {
                Vector3D vectorTemp = new Vector3D(random.NextDouble(), random.NextDouble(), random.NextDouble());
                vector = vectorTemp.Multiply(2).Substract(new Vector3D(1, 1, 1));
            } while (vector.SquaredLength() >= 1);
            return vector;
        }

        public void UpdateLastModificationDate()
        {
            LastModificationDate = DateTimeProvider.Now;
        }
        public void UpdateLastRenderizationDate()
        {
            LastRenderizationDate = DateTimeProvider.Now;
        }
        private void ValidateName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name cant be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name cant start or end with blank");
        }
    }
}
