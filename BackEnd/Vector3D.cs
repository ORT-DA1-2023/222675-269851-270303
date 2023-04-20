using System;

namespace Render3D.BackEnd
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
        public float X { get => _x; }
        public float Y { get => _y; }
        public float Z { get => _z; }
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
    }
}