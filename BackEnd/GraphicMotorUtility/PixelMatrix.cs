namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class PixelMatrix
    {
        private readonly int _width;
        private readonly int _height;

        public PixelMatrix() { }

        public PixelMatrix(int width, int height)
        {
            _width = width;
            _height = height;
            Matrix = new Colour[height, width];
        }

        public Colour[,] Matrix { get; set; }

    }
}