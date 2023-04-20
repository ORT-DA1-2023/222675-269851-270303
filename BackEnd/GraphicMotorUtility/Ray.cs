using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class Ray
    {
        private Vector3D _origin;
        private Vector3D _direction;

        public Ray(Vector3D origin, Vector3D direction)
        {
            this._origin = origin;
            this._direction = direction;
        }

        public Vector3D Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Vector3D Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector3D PointAt(int v)
        {
            throw new NotImplementedException();
        }
    }
}