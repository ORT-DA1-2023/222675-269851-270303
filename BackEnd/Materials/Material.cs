using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Utilities;
using System;

namespace Render3D.BackEnd.Materials
{

    public abstract class Material
    {
        protected string _name;
        public string Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                ValidateName(value);
                _name = value;
            }
        }
        public Client Client { get; set; }
        public Ray Ray { get; set; }



        public Colour Attenuation { get; set; }

        public abstract Ray ReflectsTheLight(HitRecord3D hitRecord);


        protected void ValidateName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Color must be between 0 and 255");

        }


        

    }
}