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
        private Vector3D _vectorUp;
        private Vector3D _vectorW;
        private Vector3D _vectorU;
        private Vector3D _vectorV;
        private Vector3D _horizontal;
        private Vector3D _vertical;
        private Vector3D _corner_lowerleft;
        private double _theta;
        private double _heightHalf;
        private double _widthHalf;
        private double _aspectRatio;
        private int _fov;
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

        public Vector3D VectorW
        {
            get => _vectorW;
            set => _vectorW = value;
        }

        public Vector3D VectorU
        {
            get => _vectorU;
            set => _vectorU = value;
        }

        public Vector3D VectorV
        {
            get => _vectorV;
            set => _vectorV = value;
        }

        public double HeightHalf
        {
            get => _heightHalf;
            set => _heightHalf = value;
        }

        public double AspectRatio
        {
            get => _aspectRatio;
            set => _aspectRatio = value;
        }

        public double WidthHalf
        {
            get => _widthHalf;
            set { _widthHalf = value; }
        }

        


        public double Theta
        {
            get => _theta;
            set
            {
                _theta = value;
                _heightHalf = Math.Tan(Theta / 2);
            }
            
        }

        public Vector3D VectorUp
        {
            get => _vectorUp;
            set => _vectorUp = value;
        }

        public Vector3D Corner_lowerLeft
        {
            get => _corner_lowerleft;
            set => _corner_lowerleft = value;
        }

        public Vector3D Horizontal
        {
            get => _horizontal;
            set => _horizontal = value;
        }
        public Vector3D Vertical
        {
            get => _vertical;
            set => _vertical = value;
        }

        public Camera()
        {
            _lookAt = new Vector3D(0, 2, 5);
            _vectorUp = new Vector3D(0, 1, 0);
            Fov = 30;
            _theta = Fov*Math.PI/180;
            _heightHalf  = Math.Tan(Theta/2);
            _aspectRatio = 16.0 / 9.0;
            _widthHalf = AspectRatio * HeightHalf;
            _lookFrom = new Vector3D(0, 2, 0);
            _vectorW = LookFrom.Substract(LookAt).GetUnit();
            _vectorU = VectorUp.Cross(VectorW).GetUnit();
            _vectorV = VectorW.Cross(VectorU);
            _corner_lowerleft = LookFrom.Substract(VectorU.Multiply((float)WidthHalf)).Substract(VectorV.Multiply((float)HeightHalf)).Substract(VectorW);
            _horizontal = VectorU.Multiply((float)WidthHalf * 2);
            _vertical = VectorV.Multiply((float)HeightHalf * 2);
        }

        public Camera(Vector3D vectorLookFrom,  Vector3D vectorLookAt, Vector3D vectorUp, int fieldOfView, double aspectRatio)
        {
            Theta = fieldOfView * Math.PI / 180;
            HeightHalf = Math.Tan(Theta / 2);
            WidthHalf = AspectRatio * HeightHalf;
            LookFrom = vectorLookFrom;
            VectorW = vectorLookFrom.Substract(vectorLookAt).GetUnit();
            VectorU = vectorUp.Cross(VectorW).GetUnit();
            VectorV = VectorW.Cross(VectorU);
            Corner_lowerLeft = LookFrom.Substract(VectorU.Multiply((float)WidthHalf)).Substract(VectorV.Multiply((float)HeightHalf)).Substract(VectorW);
            Horizontal = VectorU.Multiply((float)(2 * WidthHalf));
            Vertical = VectorV.Multiply((float)(2 * HeightHalf));
        }
        public int Fov
        {
            get => _fov;

            set
            {
                if (IsAValidName(value))
                {
                    _fov = value;
                    _theta = Fov * Math.PI / 180;
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

        public Ray GetRay(float u, float v)
        {
            Vector3D horizontalPosition = Horizontal.Multiply(u);
            Vector3D verticalPosition = Vertical.Multiply(v);
            return new Ray(LookFrom, Corner_lowerLeft.Add(horizontalPosition.Add(verticalPosition)).Substract(LookFrom));
        }
 
    }
}
