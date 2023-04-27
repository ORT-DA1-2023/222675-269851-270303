using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO.Pipes;
using System.IO;


namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class GraphicMotor
    {
        private int _resolution;
        private int _pixelSampling;
        private int _maximumDepth;

        public GraphicMotor()
        {
            _resolution = 300;
            _pixelSampling = 50;
            _maximumDepth = 20;
        }

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

        public Bitmap Render(Scene sceneSample)
        {
            throw new NotImplementedException();
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
