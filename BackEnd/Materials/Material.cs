using System;

namespace Render3D.BackEnd.Materials
{

    public abstract class Material
    {
        protected string _name;
        protected Client _client;

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

        //para donde se va el rayo

        protected void ValidateName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Color must be between 0 and 255");
        }

    }
}
