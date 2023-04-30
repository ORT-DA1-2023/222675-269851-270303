using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class Camera
    {
        private Vector3D _lookFrom;
        private Vector3D _lookAt;
        private int _fov = 30;
        private const int _minFov = 0;
        private const int _maxFov = 160;

        public Vector3D LookFrom
        {
            get => _lookFrom;
            set => _lookFrom = value;
        }
        public Vector3D LookAt
        {
            get => _lookAt;
            set => _lookAt = value;
        }

        public Camera()
        {
            Fov = 30;
            _lookFrom = new Vector3D(0, 2, 0);
            _lookAt = new Vector3D(0, 2, 5);
        }
        public int Fov
        {
            get => _fov;

            set
            {
                if (IsAValidName(value))
                {
                    _fov = value;
                }
            }
        }

        private bool IsAValidName(int value)
        {
            if (!HelperValidator.IsANumberInRange(value, _minFov, _maxFov))
            {
                throw new BackEndException($"FoV must be between {_minFov} and {_maxFov}");
            }
            return true;
        }

        public bool Equals(Camera other)
        {
            return  this.Fov == other.Fov && this.LookFrom.Equals(other.LookFrom) && this.LookAt.Equals(other.LookAt);
        }

 
    }
}
