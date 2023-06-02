using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class GraphicMotor
    {
        private int _resolutionWidth;
        private int _pixelSampling;
        private int _maximumDepth;
        private const int _resultionWidthDefault = 300;
        private const int _resolutionHeightDefault = 200;
        private const int _pixelSamplingDefault = 50;
        private const int _maximumDepthDefault = 20;

        public GraphicMotor()
        {
            ResolutionWidth = _resultionWidthDefault;
            PixelSampling = _pixelSamplingDefault;
            MaximumDepth = _maximumDepthDefault;
        }

        public int ResolutionWidth
        {
            get { return _resolutionWidth; }
            set
            {
                ValidateNumberIsGreaterThanZero(value, "resolution");
                _resolutionWidth = value;

            }
        }

        public PixelMatrix PixelMatrix { get; set; }


        public int MaximumDepth
        {
            get { return _maximumDepth; }
            set
            {
                ValidateNumberIsGreaterThanZero(value, "maximum depth");
                _maximumDepth = value;
            }
        }

        public int PixelSampling
        {
            get { return _pixelSampling; }
            set
            {
                ValidateNumberIsGreaterThanZero(value, "pixel sampling");
                _pixelSampling = value;
            }
        }

        private int ResolutionHeight()
        {
            return (ResolutionWidth * _resolutionHeightDefault) / _resultionWidthDefault;
        }

        public double AspectRatio()
        {
            return ((double)ResolutionWidth) / ResolutionHeight();
        }

        public Bitmap RenderModelPreview(Model model)
        {
            ResolutionWidth = 100;
            PixelSampling = 30;
            MaximumDepth = 10;

            Scene previewScene = new Scene();
            model.Figure.Position = new Vector3D(0, 0, 0);
            previewScene.PositionedModels.Add(model);
            Sphere sphereSample = (Sphere)model.Figure;
            double radius = sphereSample.Radius;
            Vector3D vectorUp = new Vector3D(0, 2 * radius, 0);
            Vector3D twoTimesRadius = new Vector3D(2 * radius, 2 * radius, 2 * radius);
            Camera camera = new Camera(model.Figure.Position.Add(twoTimesRadius), model.Figure.Position, vectorUp, 60, 1);
            previewScene.Camera = camera;
            return Render(previewScene);
        }

        public Bitmap Bitmap { get; set; }

        public Bitmap Render(Scene sceneSample)
        {
            int width = ResolutionWidth;
            int height = ResolutionHeight();
            PixelMatrix = new PixelMatrix(width, height);
            PixelMatrix.Matrix = CreateMatrix(sceneSample, PixelMatrix.Matrix);
            string imagePPM = CreateImagePPM(PixelMatrix.Matrix);
            Bitmap = GenerateBitmap(new Bitmap(width, height), imagePPM);
            return Bitmap;
        }

        private Bitmap GenerateBitmap(Bitmap bitmap, string imagePPM)
        {
            string[] linesImagePPM = imagePPM.Split('\n');
            for (int i = 3; i < linesImagePPM.Length - 1; i++)
            {
                var rgbValues = linesImagePPM[i].Split(' ').Select(value => (value)).ToArray();
                var r = rgbValues[0];
                var g = rgbValues[1];
                var b = rgbValues[2];
                var lineNumber = i - 3;
                var pixelColumn = lineNumber % ResolutionWidth;
                var pixelRow = lineNumber / ResolutionWidth;
                bitmap.SetPixel(pixelColumn, pixelRow, Color.FromArgb(int.Parse(r), int.Parse(g), int.Parse(b)));
            }

            return bitmap;
        }

        private Colour[,] CreateMatrix(Scene sceneSample, Colour[,] matrix)
        {
            RandomSingleton random = RandomSingleton.Instance;
            for (var row = ResolutionHeight() - 1; row >= 0; row--)
            {
                for (var column = 0; column < ResolutionWidth; column++)
                {
                    Colour pixelColor = new Colour(0, 0, 0);
                    for (int sample = 0; sample < PixelSampling; sample++)
                    {

                        double u = (column + random.NextDouble()) / ResolutionWidth;
                        double v = (row + random.NextDouble()) / ResolutionHeight();
                        Ray ray = sceneSample.Camera.GetRay(u, v);
                        pixelColor.AddTo(sceneSample.ShootRay(ray, MaximumDepth));
                    }
                    pixelColor = pixelColor.Divide(PixelSampling);
                    SavePixel(row, column, pixelColor, matrix);
                }
            }
            return matrix;
        }

        public void SavePixel(int row, int column, Colour pixelRGB, Colour[,] matrix)
        {
            int posX = column;
            int posY = ResolutionHeight() - row - 1;

            if (posY < ResolutionHeight())
            {
                matrix[posY, posX] = pixelRGB;
            }
            else
            {
                throw new BackEndException("Pixel Overflow Error");
            }
        }

        private string CreateImagePPM(Colour[,] matrix)
        {
            var width = ResolutionWidth;
            var height = ResolutionHeight();
            StringBuilder ppmString = new StringBuilder();
            ppmString.AppendLine("P3");
            ppmString.AppendLine($"{width} {height}");
            ppmString.AppendLine("255");
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Colour pixel = matrix[y, x];
                    ppmString.AppendLine($"{pixel.Red()} {pixel.Green()} {pixel.Blue()}");
                }
            }
            return ppmString.ToString();
        }

        private void ValidateNumberIsGreaterThanZero(int number, string word)
        {
            if (number <= 0) throw new BackEndException($"The {word} must be greater than 0.");
        }
    }
}
