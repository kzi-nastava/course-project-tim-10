using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.view;

namespace HealthCareInfromationSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LogInForm());
            //Constants.ReadData(Constants.connectionString, "select name from users");
            Application.Run(new view.secretaryView.SecretaryMainForm());
        }
    }
}
