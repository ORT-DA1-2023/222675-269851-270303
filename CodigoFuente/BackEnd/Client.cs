using Render3D.BackEnd.Utilities;
using System;


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


        public Client()
        {
            RegisterDate = DateTimeProvider.Now;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                ValidateName(value);
                _name = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                ValidatePassword(value);
                _password = value;
            }
        }

        public DateTime RegisterDate { get; set; }
        public string Id { get; set; }

        private void ValidateName(string value)
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

        private void ValidatePassword(string value)
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
            return Name.Equals(p.Name);
        }
    }

}
