using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;

namespace Render3D.BackEnd.Figures
{
    public abstract class Figure
    {
        protected Client _client;
        protected string _name;
        protected Vector3D _position;

        public Client Client { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                ValidateName(value);
                _name = value;
            }
        }
        public string Id { get; set; }

        public override string ToString()
        {
            return Name;
        }
        public Vector3D Position { get => _position; set => _position = value; }
       

        public abstract bool WasHit(Ray ray, double minDistance, double maxDistance);
        public abstract HitRecord3D FigureHitRecord(Ray ray, double minDistance, double maxDistance, Colour color);

        protected void ValidateName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("The name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name must not start or end with spaces");
        }

    }
}