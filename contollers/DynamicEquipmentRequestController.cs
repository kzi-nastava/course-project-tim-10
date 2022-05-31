using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.contollers
{
    class DynamicEquipmentRequestController
    {
        public static void SendRequest(int equipmentId, int quantity)
        {
            EquipmentRequest request = new EquipmentRequest(equipmentId, quantity);
            Add(request);
        }
        private static void Add(EquipmentRequest request)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string dateSent = request.DateSent.ToString("dd.MM.yyyy. HH:mm");
                String query = $"insert into equipment_request values " +
                    $"(\"{GetFirstFreeId()}\", {request.EquipmentId}, {request.Quantity}, \"{dateSent}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        private static int GetFirstFreeId()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select * from equipment_request", connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                int maxId = 0;

                while (reader.Read())
                {
                    int id = int.Parse(reader[0].ToString());
                    if (id > maxId) { maxId = id; }
                }
                reader.Close();
                return maxId + 1;
            }
        }

    }
}
