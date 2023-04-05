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

        public Figure Figure { get; set; }
        public Client Owner { get; set; }
        public Material Material { get; set; }
    }
}