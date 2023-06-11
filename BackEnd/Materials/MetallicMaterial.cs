using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Materials
{
    public class MetallicMaterial : Material
    {
        public double Blur { get; set; }

        public override Ray ReflectsTheLight(HitRecord3D hitRecord)
        {
            Ray rayScattered = new Ray(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0));
            Vector3D vectorReflected = reflect(hitRecord.Ray.Direction.GetUnit(), hitRecord.Normal);
            rayScattered.Origin = hitRecord.Intersection;
            rayScattered.Direction = vectorReflected.Add(GetRandomInUnitFigure().Multiply(hitRecord.Roughness)
            );
            if (rayScattered.Direction.DotProduct(hitRecord.Normal) > 0)
            {
                return rayScattered;
            }
            else
            {
                return null;
            }
        }

        private Vector3D reflect(Vector3D vectorV, Vector3D vectorN)
        {
            var dotVN = vectorV.DotProduct(vectorN);
            return vectorV.Substract(vectorN.Multiply(2 * dotVN));
        }

        private Vector3D GetRandomInUnitFigure()
        {
            Vector3D vector;
            do
            {
                RandomSingleton random = RandomSingleton.Instance;
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
