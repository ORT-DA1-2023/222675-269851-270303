namespace Render3D.BackEnd
{
    public class Vector3D
    {
        private int _x;
        private int _y;
        private int _z;

        public Vector3D(int v1, int v2, int v3)
        {
            this._x = v1;
            this._y = v2;
            this._z = v3;
        }
        public int X { get=> _x; }  
        public int Y { get => _y;}
        public int Z { get => _z;}
    }
}