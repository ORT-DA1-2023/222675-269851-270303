namespace Render3D.BackEnd.GraphicMotorUtility
{
    using Render3D.BackEnd.Materials;
    public class PixelMatrix
    {
        public PixelMatrix() { }

        public PixelMatrix(int width, int height)
        {
            Matrix = new Colour[height, width];
        }

        public Colour[,] Matrix { get; set; }

    }
}