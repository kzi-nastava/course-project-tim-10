using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.utils
{
    public static class Constants
    {
        public static String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\database.accdb");

        public static String DateTimeFmt = "dd.MM.yyyy. HH:mm";
        public static String DateFmt = "dd.MM.yyyy.";
        public static String TimeFmt = "HH:mm";
    }
}
