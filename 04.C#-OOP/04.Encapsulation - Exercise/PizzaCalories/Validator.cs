using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Validator
    {
        public static void CheckIfNumberIsInRange(int min, int max, int value, string exceptionMessage)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfValueIsInvalid(HashSet<string> values, string value, string exceptionMessage)
        {
            if (!values.Contains(value))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
