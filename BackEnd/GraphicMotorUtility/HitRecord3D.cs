using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class HitRecord3D
    {
        public double _module;
        public Vector3D _intersection;
        public Vector3D _normal;

        public HitRecord3D()
        {
            _module = 0;
            _intersection = new Vector3D(0, 0, 0);
            _normal = new Vector3D(0, 0, 0);
        }

        public HitRecord3D(double module, Vector3D intersection, Vector3D normal)
        { 
            _module = module;
            _intersection = intersection;
            _normal = normal;
        }

        public double Module
        {
            get => _module;
            set => _module = value;
        }

        public Vector3D Intersection
        {
            get => _intersection;
            set => _intersection = value;
        }

        public Vector3D Normal
        {
            get => _normal;
            set => _normal = value;
        }
        
    }
}
