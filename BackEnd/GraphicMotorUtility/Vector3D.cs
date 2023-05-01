using System;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class Vector3D
    {
        private float _x;
        private float _y;
        private float _z;

        public Vector3D(float v1, float v2, float v3)
        {
            X = v1;
            Y = v2;
            Z = v3;
        }
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public float Z
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
        public Vector3D Multiply(float iCount)
        {
            return new Vector3D(X * iCount, Y * iCount, Z * iCount);
        }

        public Vector3D Divide(float iCount)
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
        public float SquaredLength()
        {
            return (X * X) + (Y * Y) + (Z * Z);
        }
        public float Length()
        {
            return (float)Math.Sqrt(SquaredLength());
        }
        public Vector3D GetUnit()
        {
            return Divide((int)Length());
        }

        public float Dot(Vector3D other)
        {
            return (X * other.X) + (Y * other.Y) + (Z  * other.Z);
        }

        public Vector3D Cross(Vector3D other)
        {
            float x = Y * other.Z - Z * other.Y;
            float y = Z * other.X - X * other.Z;
            float z = X * other.Y - Y * other.X;
            return new Vector3D(x, y, z);
        }

        public bool Equals(Vector3D other)
        {
            return ((X==other.X) && (Y ==other.Y) && (Z ==other.Z));
        }
    }
}