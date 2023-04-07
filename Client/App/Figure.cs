using System;
using System;

using System.Linq;

namespace App
{
    public abstract class Figure 
    {
        private const int nameMinimumLength = 3;
        private const int nameMaximumLength = 20;
        private String name;
        private Client client;

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
        
        private bool isAValidName(String value)
        {
            if (!value.All(char.IsLetterOrDigit))
            {
                throw new BackEndException("Name must be alphanumeric");
            }
            if (value.Length < nameMinimumLength || value.Length > nameMaximumLength)
            {
                throw new BackEndException("Name length must be between 3 and 20");
            }

            return true;
        }
    }
}