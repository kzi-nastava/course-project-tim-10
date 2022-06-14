using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using HealthCareInfromationSystem.utils;
using HealthCareInfromationSystem.Core.MedicineManagment;


namespace HealthCareInfromationSystem.Core.MedicineManagment
{
	class MedicineController
	{

		internal static Medicine LoadOneById(string medicineId)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select * from medicine where id=\"" + medicineId + "\"", connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Medicine medicine = null;

				while (reader.Read())
                {
                    medicine = Medicine.Parse(reader);
                }
				reader.Close();
                return medicine;
            }
        }
    }
}
