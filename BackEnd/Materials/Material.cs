using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Materials
{

    public abstract class Material
    {
        private String name;
        private Client client;
        public virtual String Name
        {
            get => name;
            set { name = value;}

        }
        public virtual Client Client
        {
            get => client;
            set => client = value;
        }

        
    }
}
