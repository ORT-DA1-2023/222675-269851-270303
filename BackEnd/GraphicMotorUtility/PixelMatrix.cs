namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class PixelMatrix
    {
        private int[,] _matrix;

        public PixelMatrix()
        {
            
        }

        public int[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
       
    }
}