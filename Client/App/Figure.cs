using System;
using System.Linq;

namespace App
{
    public abstract class Figure 
    {
        private String name;
        private Client client;
        protected string emptyNameTextException = "The name must not be empty";
        protected string nameStartsOrEndsWithSpaceTextException = "Name must not start or end with spaces";

        public virtual Client Client
        {
            get => client;
            set => client = value;
        }

        public virtual String Name
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

        protected bool isAValidName(String value)
        {
            if (value.Length == 0) throw new BackEndException(emptyNameTextException);
            if (value.Trim().Length != value.Length) throw new BackEndException(nameStartsOrEndsWithSpaceTextException);
            return true;
        }
    }
}