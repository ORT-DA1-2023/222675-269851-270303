using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Xml.Linq;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.BackEnd
{
    public class Scene
    {
        private DateTime _registerDate;
        private DateTime _lastModificationDate;
        private Client _client;
        private String _name;
        private List<Model> _positionedModels;
        private Camera _camera;
        private Bitmap _preview;

        public Scene()
        {
            _camera = new Camera();
            _registerDate = DateTimeProvider.Now;
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

      
        public List<Model> PositionedModels { get => _positionedModels; set => _positionedModels = value; }

        public DateTime LastModificationDate
        {
            get => _lastModificationDate;
            private set => _lastModificationDate = value;
        }

        public Vector3D ShootRay(Ray ray, int depth)
        {
            HitRecord3D hitRecord = null;
            double moduleMax = Math.Pow(10, 38);
            foreach (Model element in PositionedModels)
            {
                HitRecord3D hit = element.Figure.IsFigureHit(ray, 0.001, moduleMax, element.Material.Color);
                if (hit != null)
                { 
                    hitRecord = hit;
                    moduleMax = hit.Module; 
                }
            }
            if (hitRecord!=null)
            {
                if (depth > 0)
                {

                    Vector3D newVectorPoint = hitRecord.Intersection.Add(hitRecord.Normal).Add(GetRandomInUnitSphere());
                    Vector3D newVector = newVectorPoint.Substract(hitRecord.Intersection);
                    Ray newRay = new Ray(hitRecord.Intersection, newVector);
                    Vector3D color = ShootRay(newRay, depth - 1);
                    Vector3D attenuation = hitRecord.Attenuation;
                    return new Vector3D(color.X * attenuation.X, color.Y * attenuation.Y, color.Z * attenuation.Z);
                }
                else
                {
                    return new Vector3D(0, 0, 0);
                }
            }
            else
            {
                var vectorDirectionUnit = ray.Direction.GetUnit();
                var posY = 0.5 * (vectorDirectionUnit.Y + 1);
                var colorStart = new Vector3D(1, 1, 1);
                var colorEnd = new Vector3D((float)0.5, (float)0.7, (float)1.0);
                return colorStart.Multiply((float)(1 - posY)).Add(colorEnd.Multiply((float)posY));
            }
        }

        private Vector3D GetRandomInUnitSphere()
        {
            Vector3D vector;
            do
            {
                Random random = new Random();
                Vector3D vectorTemp = new Vector3D((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                vector = vectorTemp.Multiply(2).Substract(new Vector3D(1,1,1));
            } while (vector.SquaredLength() >=1 );
            return vector;
        }

        public void UpdateLastModificationDate()
        {
            LastModificationDate = DateTimeProvider.Now;
        }
        private bool IsAValidName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name cant be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name cant start or end with blank");
            return true;
        }
        
    }
}
