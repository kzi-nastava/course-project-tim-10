using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.utils
{
    public class MyConverter
    {
        public static DateTime ToDateTime(String dateTimeStr)
        {
            DateTime t = DateTime.ParseExact(dateTimeStr, Constants.DateFmt, null);
            return t;
        }

        public static String ToString(DateTime dateTime)
        {
            return dateTime.ToString(Constants.DateFmt);
        }

    }
}
