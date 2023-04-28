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
        private Bitmap _bitmap;
        private PixelMatrix _pixelMatrix;



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

        private int WidthResolution()
        {
            return (ResolutionHeight * _resultionWidthDefault)/_resolutionHeightDefault;
        }

        public Bitmap Render(Scene sceneSample)
        {
            
            int width = WidthResolution();
            int height = ResolutionHeight;
            _pixelMatrix = new PixelMatrix(width, height);
            _pixelMatrix.Matrix = CreateMatrix(sceneSample, _pixelMatrix.Matrix);
            String imagePPM = CreateImage(_pixelMatrix.Matrix);
            _bitmap = GenerateBitmap(new Bitmap(width,height));
            return null;
        }

        private Bitmap GenerateBitmap(Bitmap bitmap)
        {
            return null;
        }

        private Color[,] CreateMatrix(Scene sceneSample, Color[,] matrix) //TODO: Change the information
        {
    
            var width = WidthResolution();
            var height = ResolutionHeight;
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    int r = 255;
                    int g = 255;
                    int b = 0;
                    matrix[x, y] = Color.FromArgb(r, g, b);
                }
            }
            return matrix;

        }

        private string CreateImage(Color[,] matrix)  
        {

            var width = WidthResolution();
            var height = ResolutionHeight;
            StringBuilder ppmString = new StringBuilder();
            ppmString.AppendLine("P3");
            ppmString.AppendLine($"{width} {height}");
            ppmString.AppendLine("255");
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = matrix[y, x];
                    ppmString.AppendLine($"{pixel.R} {pixel.G} {pixel.B}");
                }
            }
            return ppmString.ToString();
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
