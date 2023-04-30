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
using System.Text.RegularExpressions;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class GraphicMotor
    {
        private int _resolutionHeight;
        private int _pixelSampling;
        private int _maximumDepth;
        private const int _resultionWidthDefault = 2;
        private const int _resolutionHeightDefault = 3;
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

        public PixelMatrix PixelMatrix
        {
            get { return _pixelMatrix; }
            set { _pixelMatrix = value; }
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

        public Bitmap RenderModelPreview(Model model)
        {
            Scene previewScene = new Scene();
            previewScene.PositionedModels.Add(model);

            Camera camera = new Camera();
            camera.LookAt = model.Figure.Position;
            camera.LookFrom = model.Figure.Position.Add(new Vector3D(0, 0, -10));
            camera.Fov = 60;

            previewScene.Camera = camera;

            return Render(previewScene);
        }

        public Bitmap Render(Scene sceneSample)
        {
            
            int width = WidthResolution();
            int height = ResolutionHeight;
            PixelMatrix = new PixelMatrix(width, height);
            PixelMatrix.Matrix = CreateMatrix(sceneSample, _pixelMatrix.Matrix);
            String imagePPM = CreateImagePPM(_pixelMatrix.Matrix);
            _bitmap = GenerateBitmap(new Bitmap(width,height));
            return null;
        }

        private Bitmap GenerateBitmap(Bitmap bitmap)
        {
            return null;
        }

        private Vector3D[,] CreateMatrix(Scene sceneSample, Vector3D[,] matrix) 
        {
            float distanceToPlane = (float)((ResolutionHeight / 2) / Math.Tan(sceneSample.Camera.Fov / 2));
            float aspectRatio = WidthResolution() / ResolutionHeight;
            float viewportHeight = (float)(2 * distanceToPlane * Math.Tan(sceneSample.Camera.Fov / 2));
            float viewportWidth = aspectRatio * viewportHeight;

            Vector3D vectorLowerLeftCorner = new Vector3D(-viewportWidth / 2, -viewportHeight / 2, -distanceToPlane);
            Vector3D vectorHorizontal = new Vector3D(viewportWidth, 0, 0);
            Vector3D vectorVertical = new Vector3D(0, viewportHeight, 0);
            Vector3D origin = sceneSample.Camera.LookFrom;

            for (var row = ResolutionHeight - 1; row >= 0; row--)
            {
                for (var column = 0; column < WidthResolution(); column++)
                {
                    var u = column / WidthResolution();
                    var v = row / WidthResolution();
                    Vector3D horizontalPosition = vectorHorizontal.Multiply(u);
                    Vector3D verticalPosition = vectorVertical.Multiply(v);
                    Vector3D pointPosition = vectorLowerLeftCorner.Add(horizontalPosition.Add(verticalPosition));
                    Ray ray = new Ray(origin, pointPosition);
                    Vector3D pixelColor = sceneSample.ShootRay(ray);
                    SavePixel(row, column, pixelColor, matrix);
                }
            }
            return matrix;
        }

        public void SavePixel(int row, int column, Vector3D pixelRGB, Vector3D[,] matrix)
        {
            int posX = column;
            int posY = matrix.GetLength(0) - row - 1;

            if (posY < matrix.GetLength(0))
            {
                if (posX == 0)
                {
                    matrix[posY, posX] = pixelRGB;
                }
                else
                {
                    matrix[posY, posX] = pixelRGB;
                }
            }
            else
            {
                throw new BackEndException("Pixel Overflow Error");
            }
        }

        private string CreateImagePPM(Vector3D[,] matrix)  
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
                    Vector3D pixel = matrix[y, x];
                    ppmString.AppendLine($"{pixel.X} {pixel.Y} {pixel.Z}");
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
