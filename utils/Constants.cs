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
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\database.accdb");
        //public static OleDbConnection connection = new OleDbConnection(connectionString);

        public static string DateTimeFmt = "dd.MM.yyyy. HH:mm";
        public static string DateFmt = "dd.MM.yyyy.";
        public static string TimeFmt = "HH:mm";
        public static string FullTimeFmt = "HH:mm:ss";
    }
}
