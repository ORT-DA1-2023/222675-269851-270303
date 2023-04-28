using System.Drawing;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class PixelMatrix
    {
        private Color[,] _matrix;
        private int _width;
        private int _height;

        public PixelMatrix()
        {
            
        }

        public PixelMatrix(int width, int height)
        {
            _width = width;
            _height = height;
            _matrix = new Color[height, width];
        }

        public Color[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
       
    }
}