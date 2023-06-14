using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.BackEnd.Materials
{
    public class MetallicMaterial : Material
    {
        private readonly Vector3D _vectorTempMultSubstract = new Vector3D(1, 1, 1);
        private const int _minimumSquaredLength = 1;
        private readonly Vector3D _vectorOrigin000 = new Vector3D(0, 0, 0);
        private readonly Vector3D _vectorOrigin000Two = new Vector3D(0, 0, 0);
        private const int _minimumDotProduct = 0;


        public double Blur { get; set; }

        public override Ray ReflectsTheLight(HitRecord3D hitRecord)
        {
            Ray rayScattered = new Ray(_vectorOrigin000, _vectorOrigin000Two);
            Vector3D vectorReflected = Reflect(hitRecord.Ray.Direction.GetUnit(), hitRecord.Normal);
            rayScattered.Origin = hitRecord.Intersection;
            rayScattered.Direction = vectorReflected.Add(GetRandomInUnitFigure().Multiply(hitRecord.Roughness)
            );
            if (rayScattered.Direction.DotProduct(hitRecord.Normal) > _minimumDotProduct)
            {
                return rayScattered;
            }
            else
            {
                return null;
            }
        }

        private Vector3D Reflect(Vector3D vectorV, Vector3D vectorN)
        {
            var dotVN = vectorV.DotProduct(vectorN);
            return vectorV.Substract(vectorN.Multiply(2 * dotVN));
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
