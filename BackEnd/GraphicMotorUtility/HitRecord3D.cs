namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class HitRecord3D
    {
        private double _module;
        private Vector3D _intersection;
        private Vector3D _normal;
        private Vector3D _attenuation;

        public HitRecord3D()
        {
            _module = 0;
            _intersection = new Vector3D(0, 0, 0);
            _normal = new Vector3D(0, 0, 0);
            _attenuation = new Vector3D(0, 0, 0);
        }

        public HitRecord3D(double module, Vector3D intersection, Vector3D normal, Vector3D color)
        {
            _module = module;
            _intersection = intersection;
            _normal = normal;
            _attenuation = color;
        }

        public double Module { get => _module; set => _module = value; }

        public Vector3D Intersection
        {
            get => _intersection;
            set => _intersection = value;
        }

        public Vector3D Normal
        {
            get => _normal;
            set => _normal = value;
        }
        public Vector3D Attenuation
        {
            get => _attenuation;
            set => _attenuation = value;
        }
    }
}
