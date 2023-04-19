using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Render3D.BackEnd {
    public class Client : Person
    {
        private const int nameMinimumLength = 3;
        private const int nameMaximumLength = 20;
        private const int passwordMinimumLength = 5;
        private const int passwordMaximumLength = 25;
        private DateTime registerDate;
      

        public Client()
        {
            registerDate = DateTime.Now;
        }

        public DateTime RegisterDate
        {
            get => registerDate;
        }




        protected override bool IsAValidName(String value)
       {
          if (!value.All(char.IsLetterOrDigit))
           {
               throw new BackEndException("Name must be alphanumerical");
           }
          if (value.Length < nameMinimumLength || value.Length > nameMaximumLength) 
          {
              throw new BackEndException($"Name length must be between {nameMinimumLength} and {nameMaximumLength}");
          }

          return true;
       }

       protected override bool IsAValidPassword(String value)
       {
           if (!value.Any(char.IsDigit))
           {
               throw new BackEndException("Password must contain at least 1 number");
            }
           if (value.Length < passwordMinimumLength || value.Length > passwordMaximumLength)
            {
                throw new BackEndException($"Password length must be between {passwordMinimumLength} and {passwordMaximumLength}");
            }

           if (!value.Any(char.IsUpper))
            {
               throw new BackEndException("Password must contain at least one capital letter");

            }
            return true;
       }
        public override bool Equals(Person p)
        {
            return this.Name.Equals(((Client)p).Name);
        }
    }

}
