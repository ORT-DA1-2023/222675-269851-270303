using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class HelperValidator
    {
        public static bool IsLengthBetween(String name, int minLength, int maxLength)
        {
            return name.Length >= minLength && name.Length <= maxLength;
        }

        public static bool IsTrimmable(String name)
        {
            return !name.Equals(name.Trim());
        }
        public static bool IsAlphanumerical(String name)
        {
            return name.All(char.IsLetterOrDigit);
        }
        public static bool ContainsANumber(String name)
        {
            return name.Any(char.IsDigit);
        }
        public static bool ContainsACapital(String name)
        {
            return name.Any(char.IsUpper);
        }
        public static bool IsAnEmptyString(String name)
        {
            return name.Length == 0;
        }
        public static bool IsANumberInRange(int num, int min, int max) {
            return num>=min && num<=max;
        }
        public static bool IsANumberInRange(float num, float min, float max)
        {
            return num >= min && num <= max;
        }
        public static bool IsANumberInRange(Decimal num, Decimal min, Decimal max)
        {
            return num >= min && num <= max;
        }
    }
}
