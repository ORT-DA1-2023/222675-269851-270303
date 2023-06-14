using Render3D.BackEnd.Materials;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class HitRecord3D
    {
        private const int _moduleSampleDefault = 0;
        private readonly Vector3D _intersectionDefault = new Vector3D(0, 0, 0);
        private readonly Vector3D _normalDefault = new Vector3D(0, 0, 0);
        private readonly Colour _attenuationDefault = new Colour(0, 0, 0);

        public double Module { get; set; }
        public Vector3D Intersection { get; set; }
        public Vector3D Normal { get; set; }
        public Colour Attenuation { get; set; }
        public Ray Ray { get; set; }
        public int Roughness { get; set; }

        public HitRecord3D()
        {
            Module = _moduleSampleDefault;
            Intersection = _intersectionDefault;
            Normal = _normalDefault;
            Attenuation = _attenuationDefault;
        }

        public HitRecord3D(double module, Vector3D intersection, Vector3D normal, Colour color, Ray ray, int roughness)
        {
            Module = module;
            Intersection = intersection;
            Normal = normal;
            Attenuation = color;
            Ray = ray;
            Roughness = roughness;
        }

    }
}
