using Microsoft.SqlServer.Server;
using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.CodeDom;
using System.Linq;

namespace Render3D.BackEnd.Figures
{
    public class Sphere : Figure
    {
        private double radius;
        private String name;
        private Client client;
        private Vector3D position;

        public override Vector3D Position
        {
            get { return position; }    
            set { position = value;}
        }
        

        public override string Name
        {
            get => name;
            set
            {
                if (IsAValidName(value))
                {
                    name = value;
                }
            }
        }
        
        public override Client Client
        {
            get => client;
            set => client = value;
        }

        public double Radius
        {
            get => radius;
            set
            {
                if (IsAValidRadius(value))
                {
                    radius = value;
                }
            }
        }

        public Sphere()
        {
            radius = 1;
            name = "SphereSample";
            position = new Vector3D(0, 0, 0);
        }

        public Sphere(Vector3D position, double radius)
        {
            Radius = radius;
            Position = position;
        }


        public override HitRecord3D IsFigureHit(Ray ray, double tMin, double tMax, Vector3D color)
        {
            Vector3D vectorOriginCenter = ray.Origin.Substract(Position);
            var a = ray.Direction.Dot(ray.Direction);
            var b = vectorOriginCenter.Dot(ray.Direction) * 2;
            var c = vectorOriginCenter.Dot(vectorOriginCenter) - (Radius * Radius);
            var discriminant = (b * b) - (4 * a * c);
            if (discriminant < 0)
            {
                return null;
            }
            else
            {
                double t = (((-1 * b) - Math.Sqrt(discriminant)) / (2 * a));
                Vector3D intersectionPoint = ray.PointAt(t);
                Vector3D normal = intersectionPoint.Substract(Position).Divide(Radius);
                if (t < tMax && t > tMin)
                {
                    return new HitRecord3D(t, intersectionPoint, normal, color);
                }
                else
                {
                    return null;
                }
            }
        }

        private bool IsAValidRadius(double value)
        {
            if (value <= 0)
            {
                throw new BackEndException("The radius must be greater than 0");
            }
            return true;
        }

          override
        public String ToString()
        {
            return "";
        }
    }
}