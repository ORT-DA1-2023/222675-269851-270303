using System;

namespace App
{
    public class Model
    {
        private String name;
        private Figure figure;
        private Client client;
        private Material material;

        private string emptyNameTextException = "Name must not be empty";
        private string NameStartsOrEndsWithSpaceTextException = "Name must not start or end with spaces";
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
            if (name=="")throw new BackEndException(emptyNameTextException);
            if(!name.Trim().Equals(name)) throw new BackEndException(NameStartsOrEndsWithSpaceTextException);

            return true;
        }

        public Figure Figure { get=>figure; set=>figure=value; }
        public Client Client { get=>client; set=>client =value; }
        public Material Material { get=>material; set=>material=value; }
    }
}