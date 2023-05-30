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

        public override Ray ReflectsTheLight(HitRecord3D hitRecord, Random random)
        {
            throw new NotImplementedException();
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

        public override string ToString()
        {
            return Name.ToString() + " (" + Attenuation.Red() + "," + Attenuation.Green() + "," + Attenuation.Blue() + ")";
        }
    }
}
