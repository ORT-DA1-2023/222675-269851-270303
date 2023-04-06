//using BackEnd;
using System;
using System.Linq;

namespace App
{
    public class Sphere : Figure
    {
        private decimal radius;
        private String name;
        private Client client;
        private const int nameMinimumLength = 3;
        private const int nameMaximumLength = 20;
        public override string Name
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
        
        public override Client Client
        {
            get => client;
            set => client = value;
        }

        public decimal Radius
        {
            get => radius;
            set
            {
                if (isAValidRadius(value))
                {
                    radius = value;
                }
            }
        }
        private bool isAValidRadius(decimal value)
        {
            if (value <= 0)
            {
                throw new BackEndException("The radius must be greater than 0");
            }

            return true;
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