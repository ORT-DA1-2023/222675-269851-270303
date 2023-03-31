using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using App;

namespace BackEnd {
    public class Client
    {
        private const int nameMinimumLength = 3;
        private const int nameMaximumLength = 20;
        private String name;
        private String password;
        public Client()
        {

        }
        public String Name 
       {
           get => name;
            set {
               if (isAValidName(value))
               {
                  name=value;
               }
            }

       }
       public String Password
       {
           get => password;
           set
           {
               if (isNotAValidPassword(value))
               {
                  
               }
               password = value;
            }
              
       }

       private bool isAValidName(String value)
       {
          if (!value.All(char.IsLetterOrDigit))
           {
               throw new BackEndException("Name must be alphanumeric");
           }
          
          if (value.Length < nameMinimumLength || value.Length > nameMaximumLength)
          {
              throw new BackEndException("Name length must be between 3 and 20");
          }

          return true;
       }

       private bool isNotAValidPassword(String value)
       {
           return false;
       }

    }

}
