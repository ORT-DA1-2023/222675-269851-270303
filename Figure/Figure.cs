using App;
using BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public abstract class Figure
    {
        private const int nameMinimumLength = 3;
        private const int nameMaximumLength = 20;
        private String name;
        private Client client;

        public Client ClientRegistraction
        { 
            get => client;
            set => client = value;
        }

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
