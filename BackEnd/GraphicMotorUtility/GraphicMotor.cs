using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class GraphicMotor
    {
        private int _resolution;
        private int _pixelSampling;

        public int Resolution
        {

            get { return _resolution; }
            set
            {
                if (IsAValidResolutionOrPixelSampling(value, "resolution"))
                {
                    _resolution = value;
                }
            }
        }

        public int PixelSampling
        {
            get { return _pixelSampling; }
            set
            {
                if (IsAValidResolutionOrPixelSampling(value, "pixel sampling"))
                {
                    _pixelSampling = value;
                }
            }
        }

        private bool IsAValidResolutionOrPixelSampling(int value, String word)
        {
            if (value<=0)
            {
                throw new BackEndException($"The {word} must be greater than 0.");
            }
            return true;
        }
       



    }
}
