using System;

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
            if (!HelperValidator.IsLengthBetween(value, nameMinimumLength, nameMaximumLength))
            {
                throw new BackEndException($"Name length must be between {nameMinimumLength} and {nameMaximumLength}");
            }
        }

        private void ValidatePassword(String value)
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
        }
        public bool Equals(Client p)
        {
            return this.Name.Equals(p.Name);
        }
    }

}
