using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Materials
{

    public abstract class Material
    {
        private String _name;
        private Client _client;
        private Vector3D _color;
        public abstract String Name { get; set; }
        public abstract Client Client { get; set;  } 
        
        public abstract Vector3D Color { get; set; }
    }
}
