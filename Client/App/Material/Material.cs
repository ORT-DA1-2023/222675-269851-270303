using BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Material
{
    public abstract class Material
    {
        String name;
        public Material() { }
        public String Name
        {
            get => name;
            set
            {
                if (isAValidName(value))
                {
                    name = value;
                }
            }

        }
        public Client Client { get; set; }

        private bool isAValidName(string value)
        {
            return true;
        }
    }
    
}
