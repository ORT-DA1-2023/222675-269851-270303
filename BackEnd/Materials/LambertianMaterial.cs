using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.BackEnd.Materials
{

    public class LambertianMaterial : Material
    {
        public LambertianMaterial() { }

        public override Ray ReflectsTheLight(HitRecord3D hitRecord)
        {
            Vector3D newVectorPoint = hitRecord.Intersection.Add(hitRecord.Normal).Add(GetRandomInUnitFigure());
            Vector3D newVector = newVectorPoint.Substract(hitRecord.Intersection);
            return new Ray(hitRecord.Intersection, newVector);
        }

        private Vector3D GetRandomInUnitFigure()
        {
            RandomSingleton random = RandomSingleton.Instance;
            Vector3D vector;
            do
            {
                Vector3D vectorTemp = new Vector3D(random.NextDouble(), random.NextDouble(), random.NextDouble());
                vector = vectorTemp.Multiply(2).Substract(new Vector3D(1, 1, 1));
            } while (vector.SquaredLength() >= 1);
            return vector;
        }

        public override string ToString()
        {
            return Name.ToString() + " (" + Attenuation.Red() + "," + Attenuation.Green() + "," + Attenuation.Blue() + ")";
        }
    }
}
