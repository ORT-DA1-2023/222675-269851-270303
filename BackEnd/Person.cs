using System;

namespace Render3D.BackEnd
{
    public abstract class Person
    {
        protected string _name;
        protected string _password;
        protected DateTime _date;

        public String Name
        {
            get { return _name; }
            set {
                if(IsAValidName(value))
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
        public DateTime Date { get; set; }

       protected abstract bool IsAValidName(string name);
       protected abstract bool IsAValidPassword(string password);
       public abstract bool Equals(Person user);  
    }
}