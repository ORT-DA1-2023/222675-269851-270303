﻿using System;
using System.Linq;

namespace Render3D.BackEnd.Utilities
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