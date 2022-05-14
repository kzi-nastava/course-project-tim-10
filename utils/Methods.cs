using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.utils
{
    public class Methods
    {
        public static bool Between(DateTime date, DateTime lowerDate, DateTime upperDate)
        {
            return (date.CompareTo(lowerDate) > 0) && (date.CompareTo(upperDate) < 0);
        }

        public static bool NotBetween(DateTime date, DateTime lowerDate, DateTime upperDate)
        {
            return !Between(date, lowerDate, upperDate);
        }
    }
}
