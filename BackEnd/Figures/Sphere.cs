using System;
using System.Linq;

namespace Render3D.BackEnd.Figures
{
    public class Sphere : Figure
    {
        private decimal radius;
        private String name;
        private Client client;


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
    }
}