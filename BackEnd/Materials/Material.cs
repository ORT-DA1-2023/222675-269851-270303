using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.BackEnd.Materials
{

    public abstract class Material
    {
        protected string _name;
        protected Client _client;
        protected Ray _ray;
        protected Colour _attenuation;


        public String Name
        {
            get => _name;
            set
            {
                ValidateName(value);
                _name = value;
            }
        }
        public Client Client { get; set; }
        public Ray Ray
        {
            get => _ray;
            set => _ray = value;
        }

        public Colour Attenuation
        {
            get => _attenuation;
            set
            {
                _attenuation = value;
            }
        }

        public abstract Ray ReflectsTheLight(HitRecord3D hitRecord, Random random);

        protected void ValidateName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Color must be between 0 and 255");

        }


    }
}
