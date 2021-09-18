using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int GetDiffBetweenDates(string fistDateStr, string secondDateStr)
        {
            DateTime firstDate = DateTime.Parse(fistDateStr);
            DateTime secondDate = DateTime.Parse(secondDateStr);

            TimeSpan diff = firstDate - secondDate;

            return diff.Days;
        }
    }
}
