using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
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
    }
}
