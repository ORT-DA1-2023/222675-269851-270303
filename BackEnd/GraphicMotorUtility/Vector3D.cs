using System;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class Vector3D
    {
        public Vector3D(double v1, double v2, double v3)
        {
            X = v1;
            Y = v2;
            Z = v3;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
       
        public Vector3D Add(Vector3D vector3d)
        {
            return new Vector3D(X + vector3d.X, Y + vector3d.Y, Z + vector3d.Z);
        }
        public Vector3D Substract(Vector3D vector3d)
        {
            return new Vector3D(X - vector3d.X, Y - vector3d.Y, Z - vector3d.Z);
        }
        public Vector3D Multiply(double iCount)
        {
            return new Vector3D(X * iCount, Y * iCount, Z * iCount);
        }
        public Vector3D Divide(double iCount)
        {
            return new Vector3D(X / iCount, Y / iCount, Z / iCount);
        }
        public void AddTo(Vector3D vector3d)
        {
            X += vector3d.X;
            Y += vector3d.Y;
            Z += vector3d.Z;
        }
        public void SubstractFrom(Vector3D vector3d)
        {
            X -= vector3d.X;
            Y -= vector3d.Y;
            Z -= vector3d.Z;
        }
        public void ScaleUpBy(int count)
        {
            X *= count;
            Y *= count;
            Z *= count;
        }

        public void ScaleDownBy(int count)
        {
            X /= count;
            Y /= count;
            Z /= count;
        }
        public double SquaredLength()
        {
            return (X * X) + (Y * Y) + (Z * Z);
        }
        public double Length()
        {
            return Math.Sqrt(SquaredLength());
        }
        public Vector3D GetUnit()
        {
            return Divide(Length());
        }

        public double DotProduct(Vector3D other)
        {
            return (X * other.X) + (Y * other.Y) + (Z * other.Z);
        }

        public Vector3D CrossProduct(Vector3D other)
        {
            double x = Y * other.Z - Z * other.Y;
            double y = Z * other.X - X * other.Z;
            double z = X * other.Y - Y * other.X;
            return new Vector3D(x, y, z);
        }

        public bool Equals(Vector3D other)
        {
            return ((X == other.X) && (Y == other.Y) && (Z == other.Z));
        }
    }
}