using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Render3D.BackEnd
{
    public class Scene
    {
        private Client _client;
        private String _name;

        private readonly DateTime _registerDate;
        private DateTime _lastModificationDate;
        private DateTime? _lastRenderizationDate = null;

        private List<Model> _positionedModels;
        private Camera _camera;
        private Bitmap _preview;

        public Scene()
        {
            _camera = new Camera();
            _registerDate = DateTimeProvider.Now;
            _lastModificationDate = DateTimeProvider.Now;
            _positionedModels = new List<Model>();
        }


        public Client Client { get => _client; set => _client = value; }
        public Camera Camera { get => _camera; set => _camera = value; }
        public string Name
        {
            get => _name;
            set
            {
                if (IsAValidName(value))
                {
                    _name = value;
                }
            }
        }

        public DateTime RegisterDate
        {
            get => _registerDate;
        }
        public DateTime LastModificationDate
        {
            get => _lastModificationDate;
            private set => _lastModificationDate = value;
        }
        public DateTime? LastRenderizationDate
        {
            get => _lastRenderizationDate;
            private set => _lastRenderizationDate = value;
        }

        public List<Model> PositionedModels { get => _positionedModels; set => _positionedModels = value; }

        public Bitmap Preview { get => _preview; set => _preview = value; }


        public Vector3D ShootRay(Ray ray, int depth, Random random)
        {
            HitRecord3D hitRecord = null;
            double moduleMax = Math.Pow(10, 38);
            foreach (Model element in PositionedModels)
            {
                HitRecord3D hit = element.Figure.IsFigureHit(ray, 0.001, moduleMax, ((LambertianMaterial)element.Material).Color);
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
        private bool IsAValidName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name cant be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name cant start or end with blank");
            return true;
        }

    }
}
