using System;

namespace App
{
    public class Model
    {
        private string name;
        private Figure figure;
        private Client owner;
        private Material material;

        public string Name { 
            get=>name;
            set
            {
                if (isANonEmptyName(value))
                {
                    name = value;
                }
            } 
        }

        private bool isANonEmptyName(string name)
        {
            if (name=="")
            {
                throw new BackEndException("Name must not be empty");
            }
            return true;
        }

        public Figure Figure { get=>figure; set=>figure=value; }
        public Client Owner { get=>owner; set=>owner=value; }
        public Material Material { get=>material; set=>material=value; }
    }
}