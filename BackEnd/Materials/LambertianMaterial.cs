using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.BackEnd.Materials
{

    public class LambertianMaterial : Material
    {
        private readonly Vector3D _vectorTempMultSubstract = new Vector3D(1, 1, 1);
        private const int _minimumSquaredLength = 1;
        public LambertianMaterial() { }

        public override Ray ReflectsTheLight(HitRecord3D hitRecord)
        {
            Vector3D newVectorPoint = hitRecord.Intersection.Add(hitRecord.Normal).Add(GetRandomInUnitFigure());
            Vector3D newVector = newVectorPoint.Substract(hitRecord.Intersection);
            return new Ray(hitRecord.Intersection, newVector);
        }

        public override Vector3D GetRandomInUnitFigure()
        {
            RandomSingleton random = RandomSingleton.Instance;
            Vector3D vector;
            do
            {
                Vector3D vectorTemp = new Vector3D(random.NextDouble(), random.NextDouble(), random.NextDouble());
                vector = vectorTemp.Multiply(2).Substract(_vectorTempMultSubstract);
            } while (vector.SquaredLength() >= _minimumSquaredLength);
            return vector;
        }

        public override string ToString()
        {
            return Name.ToString() + " (" + Attenuation.Red() + "," + Attenuation.Green() + "," + Attenuation.Blue() + ")";
        }
    }
}
