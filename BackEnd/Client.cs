using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class Client
    {
        private const int _nameMinimumLength = 3;
        private const int _nameMaximumLength = 20;
        private const int _passwordMinimumLength = 5;
        private const int _passwordMaximumLength = 25;

        protected string _name;
        protected string _password;
        private readonly DateTime _registerDate;


        public Client()
        {
            RegisterDate = DateTimeProvider.Now;

        }

        public String Name
        {
            get { return _name; }
            set
            {
                ValidateName(value);
                _name = value;
            }
        }
        public String Password
        {
            get { return _password; }
            set
            {
                ValidatePassword(value);
                _password = value;
            }
        }

        public DateTime RegisterDate { get; }

        private void ValidateName(String value)
        {
            if (!HelperValidator.IsAlphanumerical(value))
            {
                throw new BackEndException("Name must be alphanumerical");
            }
            if (!HelperValidator.IsLengthBetween(value, _nameMinimumLength, _nameMaximumLength))
            {
                throw new BackEndException($"Name length must be between {_nameMinimumLength} and {_nameMaximumLength}");
            }
        }

        private void ValidatePassword(String value)
        {
            if (!HelperValidator.IsAlphanumerical(value))
            {
                throw new BackEndException("Password must be alphanumerical");
            }
            if (!HelperValidator.IsLengthBetween(value, _passwordMinimumLength, _passwordMaximumLength))
            {
                throw new BackEndException($"Password length must be between {_passwordMinimumLength} and {_passwordMaximumLength}");
            }
            if (!HelperValidator.ContainsANumber(value))
            {
                throw new BackEndException("Password must contain at least one number");
            }
            if (!HelperValidator.ContainsACapital(value))
            {
                throw new BackEndException("Password must contain at least one capital letter");

            }
        }
        public bool Equals(Client p)
        {
            return this.Name.Equals(p.Name);
        }
    }

}
