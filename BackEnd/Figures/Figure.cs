using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Linq;

namespace Render3D.BackEnd.Figures
{
    public abstract class Figure
    {
        private String _name;
        private Client _client;
        private Vector3D _position;


        public abstract Client Client { get; set; }
        public abstract string Name { get; set; }
        public abstract Vector3D Position { get; set; }

        public abstract HitRecord3D IsFigureHit(Ray ray, double tMin, double tMax, Vector3D color);
        

        protected bool IsAValidName(String value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("The name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name must not start or end with spaces");
            return true;
        }
    }
}