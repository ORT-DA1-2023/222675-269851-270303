using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
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
            double squaredTerm = ray.Direction.DotProduct(ray.Direction);
            double linearTerm = vectorOriginCenter.DotProduct(ray.Direction) * 2;
            double independentTerm = vectorOriginCenter.DotProduct(vectorOriginCenter) - (Radius * Radius);
            double discriminant = (linearTerm * linearTerm) - (4 * squaredTerm * independentTerm);
            if (discriminant < 0)
            {
                return false;
            }
            double distance = ((-linearTerm - Math.Sqrt(discriminant)) / (2 * squaredTerm));
            return HelperValidator.IsANumberInRange(distance, minDistance, maxDistance);

        }

        public override HitRecord3D FigureHitRecord(Ray ray, double tMin, double tMax, Colour color)
        {
            Vector3D vectorOriginCenter = ray.Origin.Substract(Position);
            double squaredTerm = ray.Direction.DotProduct(ray.Direction);
            double linearTerm = vectorOriginCenter.DotProduct(ray.Direction) * 2;
            double independentTerm = vectorOriginCenter.DotProduct(vectorOriginCenter) - (Radius * Radius);
            double discriminant = (linearTerm * linearTerm) - (4 * squaredTerm * independentTerm);
            double distance = (((-1 * linearTerm) - Math.Sqrt(discriminant)) / (2 * squaredTerm));
            Vector3D intersectionPoint = ray.PointAt(distance);
            Vector3D normal = intersectionPoint.Substract(Position).Divide(Radius);
            return new HitRecord3D(distance, intersectionPoint, normal, color);
        }

        private void ValidateRadius(double value)
        {
            if (value <= 0)
            {
                throw new BackEndException("The radius must be greater than 0");
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + _radius;
        }
    }
}