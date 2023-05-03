using System;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class Vector3D
    {
        private double _x;
        private double _y;
        private double _z;

        public Vector3D(double v1, double v2, double v3)
        {
           
            X = v1;
            Y = v2;
            Z = v3;
        }
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }
        public int Red()
        {
           return (int)Math.Abs(Math.Round(X * 255));
        }

        public int Green()
        {
           return (int)Math.Abs(Math.Round(Y * 255));
          
        }

        public int Blue()
        {
            return (int)Math.Abs(Math.Round(Z * 255));
        }
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

        public double Dot(Vector3D other)
        {
            return (X * other.X) + (Y * other.Y) + (Z  * other.Z);
        }

        public Vector3D Cross(Vector3D other)
        {
            double x = Y * other.Z - Z * other.Y;
            double y = Z * other.X - X * other.Z;
            double z = X * other.Y - Y * other.X;
            return new Vector3D(x, y, z);
        }

        public bool Equals(Vector3D other)
        {
            return ((X==other.X) && (Y ==other.Y) && (Z ==other.Z));
        }
    }
}