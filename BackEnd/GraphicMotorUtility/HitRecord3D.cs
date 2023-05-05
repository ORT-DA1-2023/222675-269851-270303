namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class HitRecord3D
    {
        public HitRecord3D()
        {
            Module = 0;
            Intersection = new Vector3D(0, 0, 0);
            Normal = new Vector3D(0, 0, 0);
            Attenuation = new Vector3D(0, 0, 0);
        }

        public HitRecord3D(double module, Vector3D intersection, Vector3D normal, Vector3D color)
        {
            Module = module;
            Intersection = intersection;
            Normal = normal;
            Attenuation = color;
        }
        public double Module { get; set; }

        public Vector3D Intersection { get; set; }
        public Vector3D Normal { get; set; }
        public Vector3D Attenuation { get; set; }
    }
}
