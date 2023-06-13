namespace Render3D.BackEnd.GraphicMotorUtility
{
    using Render3D.BackEnd.Materials;
    public class PixelMatrix
    {
        public Colour[,] Matrix { get; set; }
        public PixelMatrix() { }

        public PixelMatrix(int width, int height)
        {
            Matrix = new Colour[height, width];
        }
    }
}