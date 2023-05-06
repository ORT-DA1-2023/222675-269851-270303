using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.BackEnd.Materials
{

    public class LambertianMaterial : Material
    {
        public override Ray ReflectsTheLight(HitRecord3D hitRecord, Random random)
        {
            Vector3D newVectorPoint = hitRecord.Intersection.Add(hitRecord.Normal).Add(GetRandomInUnitFigure(random));
            Vector3D newVector = newVectorPoint.Substract(hitRecord.Intersection);
            return new Ray(hitRecord.Intersection, newVector);
        }

        private Vector3D GetRandomInUnitFigure(Random random)
        {
            Vector3D vector;
            do
            {
                Vector3D vectorTemp = new Vector3D(random.NextDouble(), random.NextDouble(), random.NextDouble());
                vector = vectorTemp.Multiply(2).Substract(new Vector3D(1, 1, 1));
            } while (vector.SquaredLength() >= 1);
            return vector;
        }
        public override Client Client
        {
            get => client;
            set => client = value;
        }
        public override Vector3D Color { 
            get => color;
            set { 
                if(IsAValidColor(value))
                {
                    color = value;
                }
            } 
        }

        private bool IsAValidColor(Vector3D value)
        {
            if(!HelperValidator.IsANumberInRange(value.X,0,255) || !HelperValidator.IsANumberInRange(value.Y, 0, 255) || 
                !HelperValidator.IsANumberInRange(value.Z, 0, 255))
            {
                throw new BackEndException("Color must be between 0 and 255");
            }

          return true;
        }

        private bool IsAValidName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Color must be between 0 and 255");
            return true;
        }
        override
            public String ToString()
        {
            return base.ToString()+ " ("+ color.X +","+color.Y +","+color.Z+")";    
        }
    }
}
