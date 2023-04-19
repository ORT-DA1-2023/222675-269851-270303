using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Materials
{

    public class LambertianMaterial : Material
    {
        private String name;
        private Client client;
        private int[] color;

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
        public int[] Color
        {
            get => color;
            set
            {
                if (IsAValidColor(value))
                {
                    color = value;
                }
            }
        }

        private bool IsAValidColor(int[] value)
        {
            foreach (int code in value)
            {
                if (code < 0 || code > 255) throw new BackEndException("Color must be between 0 and 255");
            }
            return true;
        }

        private bool IsAValidName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Color must be between 0 and 255");
            return true;
        }

    }
}
