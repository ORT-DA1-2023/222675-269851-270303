using System;
using System.Linq;

namespace Render3D.BackEnd.Figures
{
    public abstract class Figure 
    {
        private String _name;
        private Client _client;


        public virtual Client Client
        {
            get => _client;
            set => _client = value;
        }

        public virtual String Name
        {
            get => _name;
            set
            {
                if (IsAValidName(value))
                {
                    _name = value;
                }
            }

        }

        protected bool IsAValidName(String value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("The name must not be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name must not start or end with spaces");
            return true;
        }
    }
}