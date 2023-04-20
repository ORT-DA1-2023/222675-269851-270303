using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class Client
    {
        private const int nameMinimumLength = 3;
        private const int nameMaximumLength = 20;
        private const int passwordMinimumLength = 5;
        private const int passwordMaximumLength = 25;

        protected string _name;
        protected string _password;
        private DateTime _registerDate;


        public Client()
        {
            _registerDate = DateTimeProvider.Now;
            
        }

        public String Name
        {
            get { return _name; }
            set
            {
                if (IsAValidName(value))
                {
                    _name = value;
                }
            }
        }
        public String Password
        {
            get { return _password; }
            set
            {
                if (IsAValidPassword(value))
                {
                    _password = value;
                }
            }
        }

        public DateTime RegisterDate
        {
            get => _registerDate;
        }

        protected bool IsAValidName(String value)
        {
            if(!HelperValidator.IsAlphanumerical(value))
            {
                throw new BackEndException("Name must be alphanumerical");
            }
            if (!HelperValidator.IsLengthBetween(value, nameMinimumLength, nameMaximumLength))
            {
                throw new BackEndException($"Name length must be between {nameMinimumLength} and {nameMaximumLength}");
            }
            return true;
        }

        private bool IsAValidPassword(String value)
        {
            if (!HelperValidator.IsAlphanumerical(value))
            {
                throw new BackEndException("Password must contain at least 1 number");
            }
            if (!HelperValidator.IsLengthBetween(value, nameMinimumLength, nameMaximumLength))
            {
                throw new BackEndException($"Password length must be between {passwordMinimumLength} and {passwordMaximumLength}");
            }

            if (!HelperValidator.ContainsACapital(value))
            {
                throw new BackEndException("Password must contain at least one capital letter");

            }
            return true;
        }
        public bool Equals(Client p)
        {
            return this.Name.Equals(p.Name);
        }
    }

}
