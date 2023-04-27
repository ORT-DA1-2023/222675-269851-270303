using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO.Pipes;
using System.IO;
using System.ComponentModel.Design;
using System.Runtime.Remoting.Messaging;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class GraphicMotor
    {
        private int _resolutionHeight;
        private int _pixelSampling;
        private int _maximumDepth;
        private const int _resultionWidthDefault = 200;
        private const int _resolutionHeightDefault = 300;
        private const int _pixelSamplingDefault = 50;
        private const int _maximumDepthDefault = 20;

        public GraphicMotor()
        {
            _resolutionHeight = _resolutionHeightDefault;
            _pixelSampling = _pixelSamplingDefault;
            _maximumDepth = _maximumDepthDefault;
        }

        public int ResolutionHeight
        {

            get { return _resolutionHeight; }
            set
            {
                if (IsAValidTheProperties(value, "resolution"))
                {
                    _resolutionHeight = value;
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

        private int HeightResolution()
        {
            return (ResolutionHeight * _resultionWidthDefault)/_resolutionHeightDefault;
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
