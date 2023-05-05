using System;

namespace Render3D.BackEnd.Materials
{

    public abstract class Material
    {
        protected String _name;
        protected Client _client;

        public abstract String Name { get; set; }
        public abstract Client Client { get; set; }

        //para donde se va el rayo

        protected bool IsAValidName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Color must be between 0 and 255");
            return true;
        }

    }
}
