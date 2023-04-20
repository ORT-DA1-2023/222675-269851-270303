using System;
using System.Linq;

namespace Render3D.BackEnd.Figures
{
    public abstract class Figure
    {
        private String _name;
        private Client _client;


        public abstract Client Client { get; set; }
        public abstract string Name { get; set; }
        protected bool IsAValidName(String value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("The name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name must not start or end with spaces");
            return true;
        }
    }
}