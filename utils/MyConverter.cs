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
            return DateTime.ParseExact(dateTimeStr, Constants.DateTimeFmt, null);
        }

        public static String ToString(DateTime dateTime)
        {
            return dateTime.ToString(Constants.DateTimeFmt);
        }

        public static DateTime ToDate(string dateStr)
        {
            return DateTime.ParseExact(dateStr, Constants.DateFmt, null);
        }

        public static DateTime ToTime(string timeStr)
        {
            return DateTime.ParseExact(timeStr, Constants.TimeFmt, null);
        }

        public static DateTime ToFullTime(string fullTimeStr)
        {
            return DateTime.ParseExact(fullTimeStr, Constants.FullTimeFmt, null);
        }

        public static DateTime CalculateDateTime(DateTime currDay, DateTime currTime)
        {
            return new DateTime(currDay.Year, currDay.Month, currDay.Day, currTime.Hour, currTime.Minute, currTime.Second);
        }

    }
}
