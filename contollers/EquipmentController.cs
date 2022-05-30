using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.contollers
{
	class EquipmentController
	{
        public static List<Equipment> LoadEquipments(string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Equipment> equipments = new List<Equipment>();

                while (reader.Read())
                {
                    Equipment equipment = Equipment.Parse(reader);
                    equipments.Add(equipment);
                }
                reader.Close();
                return equipments;
            }
        }
    }
}
