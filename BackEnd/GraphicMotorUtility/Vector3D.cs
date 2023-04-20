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
            this._x = v1;
            this._y = v2;
            this._z = v3;
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
        public int Red
        {
            get { return (int)Math.Abs(Math.Round(_x * 255)); }
        }

        public int Green
        {
            get { return (int)Math.Abs(Math.Round(_y * 255)); }
        }

        public int Blue
        {
            get { return (int)Math.Abs(Math.Round(_z * 255)); }
        }
        public Vector3D Add(Vector3D vector3d)
        {
            return new Vector3D(_x + vector3d.X, _y + vector3d.Y, _z + vector3d.Z);
        }
        public Vector3D Substract(Vector3D vector3d)
        {
            return new Vector3D(_x - vector3d.X, _y - vector3d.Y, _z - vector3d.Z);
        }
        public Vector3D Multiply(float iCount)
        {
            return new Vector3D(_x * iCount, _y * iCount, _z * iCount);
        }

        public Vector3D Divide(float iCount)
        {
            return new Vector3D(_x / iCount, _y / iCount, _z / iCount);
        }

        public void AddTo(Vector3D vector3d)
        {
            _x += vector3d.X;
            _y += vector3d.Y;
            _z += vector3d.Z;
        }

        public void SubstractFrom(Vector3D vector3d)
        {
            _x -= vector3d.X;
            _y -= vector3d.Y;
            _z -= vector3d.Z;
        }
        public void ScaleUpBy(int count)
        {
            _x *= count;
            _y *= count;
            _z *= count;
        }

        public void ScaleDownBy(int count)
        {
            _x /= count;
            _y /= count;
            _z /= count;
        }
        public float SquaredLength()
        {
            return (_x * _x) + (_y * _y) + (_z * _z);
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
            return (_x * other.X) + (_y * other.Y) + (_z * other.Z);
        }

        public Vector3D Cross(Vector3D other)
        {
            float x = _y * other.Z - _z * other.Y;
            float y = _z * other.X - _x * other.Z;
            float z = _x * other.Y - _y * other.X;
            return new Vector3D(x, y, z);
        }

        public bool equals(Vector3D other)
        {
            return ((_x==other.X) && (_y==other.Y) && (_z==other.Z));
        }
    }
}