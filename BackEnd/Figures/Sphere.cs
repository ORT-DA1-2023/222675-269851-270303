using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Linq;

namespace Render3D.BackEnd.Figures
{
    public class Sphere : Figure
    {
        private decimal radius;
        private String name;
        private Client client;
        private Vector3D position;

        public override Vector3D Position
        {
            get { return position; }    
            set { position = value;}
        }
        

        public override string Name
        {
            get => name;
            set
            {
                if (IsAValidName(value))
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
                if (IsAValidRadius(value))
                {
                    radius = value;
                }
            }
        }

        public override bool IsFigureHit(Vector3D pointIntersectionSample, Vector3D normalSample, decimal moduleSample)
        {
            return true;
        }

        private bool IsAValidRadius(decimal value)
        {
            if (value <= 0)
            {
                throw new BackEndException("The radius must be greater than 0");
            }
            return true;
        }
    }
}