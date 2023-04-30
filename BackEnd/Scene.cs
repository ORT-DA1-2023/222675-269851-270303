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
        }


        public Client Client { get => _client; set => _client = value; }
        public Camera Camera { get; set; }
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

      
        public ArrayList PositionedModels { get; set; }

        public DateTime LastModificationDate
        {
            get => _lastModificationDate;
            private set => _lastModificationDate = value;
        }

        public Vector3D ShootRay(Ray ray)
        {
            HitRecord3D hitRecord = new HitRecord3D();
            double moduleMax = 3.4 * Math.Pow(10, 38);
            foreach (Model element in PositionedModels)
            {
                HitRecord3D hit = element.Figure.IsFigureHit(ray, 0, moduleMax);
                if (hit != null)
                { 
                    hitRecord = hit;
                    moduleMax = hit.Module; 
                }
            }
            if (hitRecord!=null)
            { 
                var vectorColor = new Vector3D(hitRecord.Normal.X + 1, hitRecord.Normal.Y + 1, hitRecord.Normal.Z + 1);
                return vectorColor.Multiply((float)0.5);
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
