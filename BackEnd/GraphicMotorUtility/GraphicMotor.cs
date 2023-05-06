using System;
using System.Drawing;
using System.Linq;
using System.Text;

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

        public GraphicMotor()
        {
            ResolutionHeight = _resolutionHeightDefault;
            PixelSampling = _pixelSamplingDefault;
            MaximumDepth = _maximumDepthDefault;
        }

        public int ResolutionHeight
        {
            get { return _resolutionHeight; }
            set
            {
                ValidateNumberIsGreaterThanZero(value, "resolution");
                _resolutionHeight = value;

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

        private int WidthResolution()
        {
            return (ResolutionHeight * _resultionWidthDefault) / _resolutionHeightDefault;
        }


        public int AspectRatio()
        {
            return ResolutionHeight / WidthResolution();
        }

        public Bitmap RenderModelPreview(Model model)
        {
            Scene previewScene = new Scene();
            previewScene.PositionedModels.Add(model);

            Camera camera = new Camera
            {
                LookAt = model.Figure.Position,
                LookFrom = model.Figure.Position.Add(new Vector3D(0, 0, -10)),
                Fov = 60
            };

            previewScene.Camera = camera;

            return Render(previewScene);
        }

        public Bitmap Bitmap { get; set; }

        public Bitmap Render(Scene sceneSample)
        {
            int width = WidthResolution();
            int height = ResolutionHeight;
            PixelMatrix = new PixelMatrix(width, height);
            PixelMatrix.Matrix = CreateMatrix(sceneSample, PixelMatrix.Matrix);
            String imagePPM = CreateImagePPM(PixelMatrix.Matrix);
            Bitmap = GenerateBitmap(new Bitmap(width, height), imagePPM);
            return Bitmap;
        }

        private Bitmap GenerateBitmap(Bitmap bitmap, String imagePPM)
        {
            string[] linesImagePPM = imagePPM.Split('\n');
            for (int i = 3; i < linesImagePPM.Length - 1; i++)
            {
                var rgbValues = linesImagePPM[i].Split(' ').Select(value => (value)).ToArray();
                var r = rgbValues[0];
                var g = rgbValues[1];
                var b = rgbValues[2];
                var lineNumber = i - 3;
                var pixelColumn = lineNumber % WidthResolution();
                var pixelRow = lineNumber / WidthResolution();
                bitmap.SetPixel(pixelColumn, pixelRow, Color.FromArgb(int.Parse(r), int.Parse(g), int.Parse(b)));
            }

            return bitmap;
        }

        private Colour[,] CreateMatrix(Scene sceneSample, Colour[,] matrix)
        {
            Random random = new Random();
            for (var row = ResolutionHeight - 1; row >= 0; row--)
            {
                for (var column = 0; column < WidthResolution(); column++)
                {
                    Colour pixelColor = new Colour (0,0,0);
                    for (int sample = 0; sample < PixelSampling; sample++)
                    {

                        double u = (column + random.NextDouble()) / WidthResolution();
                        double v = (row + random.NextDouble()) / ResolutionHeight;
                        Ray ray = sceneSample.Camera.GetRay(u, v);
                        pixelColor.AddTo(sceneSample.ShootRay(ray, MaximumDepth, random));
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
            int posY = ResolutionHeight - row - 1;

            if (posY < ResolutionHeight)
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
                    Colour pixel = matrix[y, x];
                    ppmString.AppendLine($"{pixel.Red()} {pixel.Green()} {pixel.Blue()}");
                }
            }
            Console.WriteLine(ppmString.ToString());
            return ppmString.ToString();
        }

        private void ValidateNumberIsGreaterThanZero(int number, String word)
        {
            if (number <= 0) throw new BackEndException($"The {word} must be greater than 0.");
        }
    }
}
