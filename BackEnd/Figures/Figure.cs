using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Linq;

namespace Render3D.BackEnd.Figures
{
    public abstract class Figure
    {
        protected String _name;
        protected Client _client;
        protected Vector3D _position;

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

        public  Client Client
        {
            get => _client;
            set => _client = value;
        }

        public  Vector3D Position
        {
            get => _position;
            set => _position = value;
        }

        public abstract HitRecord3D IsFigureHit(Ray ray, double tMin, double tMax, Vector3D color);
        

        protected bool IsAValidName(String value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("The _name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name must not start or end with spaces");
            return true;
        }
    }
}