using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.BackEnd.Figures
{
    public class Sphere : Figure
    {
        private double _radius;

        public double Radius
        {
            get => _radius;
            set
            {
                ValidateRadius(value);
                _radius = value;
            }
        }

        public Sphere()
        {
            _radius = 1;
            _name = "SphereSample";
            _position = new Vector3D(0, 0, 0);
        }

        public Sphere(Vector3D position, double radius)
        {
            Radius = radius;
            Position = position;
        }


        public override HitRecord3D IsFigureHit(Ray ray, double tMin, double tMax, Vector3D color)
        {
            Vector3D vectorOriginCenter = ray.Origin.Substract(Position);
            //(ray.Position);
            var a = ray.Direction.DotProduct(ray.Direction);
            var b = vectorOriginCenter.DotProduct(ray.Direction) * 2;
            var c = vectorOriginCenter.DotProduct(vectorOriginCenter) - (Radius * Radius);
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

        private void ValidateRadius(double value)
        {
            if (value <= 0)
            {
                throw new BackEndException("The _radius must be greater than 0");
            }
        }
    }
}