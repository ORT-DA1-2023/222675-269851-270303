using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Materials
{

    public class LambertianMaterial : Material
    {
        private String name;
        private Client client;
        private Vector3D color;

        public override string Name
        {
            get => name;
            set
            {
                if (IsAValidName(value))
                {
                    name = value;
                }
            }
        }
        public override Client Client
        {
            get => client;
            set => client = value;
        }
        public override Vector3D Color { 
            get => color;
            set { 
                if(IsAValidColor(value))
                {
                    color = value;
                }
            } 
        }

        private bool IsAValidColor(Vector3D value)
        {
            if(!HelperValidator.IsANumberInRange(value.X,0,255) || !HelperValidator.IsANumberInRange(value.Y, 0, 255) || 
                !HelperValidator.IsANumberInRange(value.Z, 0, 255))
            {
                throw new BackEndException("Color must be between 0 and 255");
            }

          return true;
        }

        private bool IsAValidName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Color must be between 0 and 255");
            return true;
        }
        override
            public String ToString()
        {
            return base.ToString()+ " ("+ color.X +","+color.Y +","+color.Z+")";    
        }
    }
}
