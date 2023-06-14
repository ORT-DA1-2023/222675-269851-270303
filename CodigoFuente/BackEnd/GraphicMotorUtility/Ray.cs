namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class Ray
    {
        public Ray(Vector3D origin, Vector3D direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Vector3D Origin { get; set; }

        public Vector3D Direction { get; set; }

        public Vector3D PointAt(double PosX)
        {
            return Origin.Add((Direction.Multiply(PosX)));
        }
    }
}