using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App {
    public class Client
    {
        private const int nameMinimumLength = 3;
        private const int nameMaximumLength = 20;
        private const int passwordMinimumLength = 5;
        private const int passwordMaximumLength = 25;
        private DateTime registerDate;
        private String name;
        private String password;
        private ArrayList ownedFigures=new ArrayList();
        private ArrayList ownedMaterials = new ArrayList();
        private ArrayList ownedModels = new ArrayList();

        private static string nonAlphanumericPasswordTextException = "Name must be alphanumerical";
        private static string outOfRangeNameTextException = $"Name length must be between {nameMinimumLength} and {nameMaximumLength}";
        private static string outOfRangePasswordTextException = $"Password length must be between {passwordMinimumLength} and {passwordMaximumLength}";
        private static string nonNumbersAtPasswordTextException = "Password must contain at least 1 number";
        private static string nonCapitalsAtPasswordTextException = "Password must contain at least one capital letter";
        public Client()
        {
            registerDate = DateTime.Now;
        }

        public DateTime RegisterDate
        {
            get => registerDate;
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
               if (isAValidPassword(value))
               {
                   password = value;
                }
               
            }
              
       }
        public ArrayList OwnedFigures { get => ownedFigures; }
        public ArrayList OwnedMaterials { get => ownedMaterials; }
        public ArrayList OwnedModels { get => ownedModels; }


        private bool isAValidName(String value)
       {
          if (!value.All(char.IsLetterOrDigit))
           {
               throw new BackEndException(nonAlphanumericPasswordTextException);
           }
          if (value.Length < nameMinimumLength || value.Length > nameMaximumLength) 
          {
              throw new BackEndException(outOfRangeNameTextException);
          }

          return true;
       }

       private bool isAValidPassword(String value)
       {
           if (!value.Any(char.IsDigit))
           {
               throw new BackEndException(nonNumbersAtPasswordTextException);
            }
           if (value.Length < passwordMinimumLength || value.Length > passwordMaximumLength)
            {
                throw new BackEndException(outOfRangePasswordTextException);
            }

           if (!value.Any(char.IsUpper))
            {
               throw new BackEndException(nonCapitalsAtPasswordTextException);

            }

           /*if (!value.Any(char.IsLower))
           {
               throw new BackEndException("Password must contain at least one lower case letter");

           }*/

            return true;
       }
        public override bool Equals(object obj)
        {
            return this.name.Equals(((Client)obj).name);
        }

    }

}
