using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    
    public class lambertianMaterial :Material
    {
        private String name;
        private Client client;
        private int[] color;

        public override string Name 
        { 
            get =>name;
            set { 
                if(isAValidName(value))
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
                if (isAValidColor(value))
                {
                    color=value;
                }
            }
        }

        private bool isAValidColor(int[] value)
        {
           for(int i=0; i < value.Length; i++)
            {
                if (value[i]<0 || value[i] > 255)
                {
                    throw new BackEndException("Color must be between 0 and 255");
                }
            }
            
            return true;
        }

        private bool isAValidName(string value)
        {
           if(value == "")
            {
                throw new BackEndException("Name must not be empty");
            }
            if (value !=value.Trim())
            {
                throw new BackEndException("Name must not start or end with spaces");
            }
            return true;
        }
        
    }
}
