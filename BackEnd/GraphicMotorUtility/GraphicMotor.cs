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
        private int _maximumDepth;

        public int Resolution
        {

            get { return _resolution; }
            set
            {
                if (IsAValidTheProperties(value, "resolution"))
                {
                    _resolution = value;
                }
            }
        }

        public int MaximumDepth
        { 
            get { return _maximumDepth; }
            set
            {
                if (IsAValidTheProperties(value, "maximum depth"))
                {
                    _maximumDepth = value;
                }
            }
        }

        public int PixelSampling
        {
            get { return _pixelSampling; }
            set
            {
                if (IsAValidTheProperties(value, "pixel sampling"))
                {
                    _pixelSampling = value;
                }
            }
        }

        
        private bool IsAValidTheProperties(int value, String word)
        {
            if (value<=0)
            {
                throw new BackEndException($"The {word} must be greater than 0.");
            }
            return true;
        }
       



    }
}
