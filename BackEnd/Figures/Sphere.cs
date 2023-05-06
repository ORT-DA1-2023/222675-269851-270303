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

        public override bool WasHit(Ray ray, double minDistance, double maxDistance)
        {
            Vector3D vectorOriginCenter = ray.Origin.Substract(Position);
            double a = ray.Direction.DotProduct(ray.Direction);
            double b = vectorOriginCenter.DotProduct(ray.Direction) * 2;
            double c = vectorOriginCenter.DotProduct(vectorOriginCenter) - (Radius * Radius);
            double discriminant = (b * b) - (4 * a * c);
            if (discriminant < 0)
            {
                return false;
            }
            double t = ((-b - Math.Sqrt(discriminant)) / (2 * a));
            return HelperValidator.IsANumberInRange(t, minDistance, maxDistance);

        }

        public override HitRecord3D FigureHitRecord(Ray ray, double tMin, double tMax, Colour color)
        {
            Vector3D vectorOriginCenter = ray.Origin.Substract(Position);
            double a = ray.Direction.DotProduct(ray.Direction);
            double b = vectorOriginCenter.DotProduct(ray.Direction) * 2;
            double c = vectorOriginCenter.DotProduct(vectorOriginCenter) - (Radius * Radius);
            double discriminant = (b * b) - (4 * a * c);
            double t = (((-1 * b) - Math.Sqrt(discriminant)) / (2 * a));
            Vector3D intersectionPoint = ray.PointAt(t);
            Vector3D normal = intersectionPoint.Substract(Position).Divide(Radius);
            return new HitRecord3D(t, intersectionPoint, normal, color);
        }

        private void ValidateRadius(double value)
        {
            if (value <= 0)
            {
                throw new BackEndException("The radius must be greater than 0");
            }
        }
    }
}