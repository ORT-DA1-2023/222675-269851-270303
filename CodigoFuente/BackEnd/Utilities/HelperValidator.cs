using System.Linq;

namespace Render3D.BackEnd.Utilities
{
    public class HelperValidator
    {
        private const int _notALengthName = 0;
        public static bool IsLengthBetween(string name, int minLength, int maxLength)
        {
            return name.Length >= minLength && name.Length <= maxLength;
        }

        public static bool IsTrimmable(string name)
        {
            return !name.Equals(name.Trim());
        }
        public static bool IsAlphanumerical(string name)
        {
            return name.All(char.IsLetterOrDigit);
        }
        public static bool ContainsANumber(string name)
        {
            return name.Any(char.IsDigit);
        }
        public static bool ContainsACapital(string name)
        {
            return name.Any(char.IsUpper);
        }
        public static bool IsAnEmptyString(string name)
        {
            return name.Length == _notALengthName;
        }
        public static bool IsANumberInRange(int num, int min, int max)
        {
            return num >= min && num <= max;
        }
        public static bool IsANumberInRange(double num, double min, double max)
        {
            return num >= min && num <= max;
        }

    }
}
