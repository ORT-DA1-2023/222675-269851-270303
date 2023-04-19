using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System;

namespace Render3D.BackEnd
{
    public class Model
    {
        private String name;
        private Figure figure;
        private Client client;
        private Material material;


        public string Name { 
            get=>name;
            set
            {
                if (isAValidName(value))
                {
                    name = value;
                }
            } 
        }

        private bool isAValidName(string name)
        {
            if (name=="")throw new BackEndException("Name must not be empty");
            if(!name.Trim().Equals(name)) throw new BackEndException("Name must not start or end with spaces");

            return true;
        }

        public Figure Figure { get=>figure; set=>figure=value; }
        public Client Client { get=>client; set=>client =value; }
        public Material Material { get=>material; set=>material=value; }
    }
}