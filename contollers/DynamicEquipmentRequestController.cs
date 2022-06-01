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
        private static void Add(EquipmentRequest request)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string dateSent = request.DateSent.ToString("dd.MM.yyyy. HH:mm");
                String query = $"insert into equipment_request values " +
                    $"(\"{GetFirstFreeId()}\", {request.EquipmentId}, {request.Quantity}, \"{dateSent}\", \"false\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static List<EquipmentRequest> GetAll()
        {
            List<EquipmentRequest> requests = new List<EquipmentRequest>();
            string query = "select * from equipment_request where supplied=\"false\"";
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    requests.Add(Parse(reader));
                }
                reader.Close();
                return requests;
            }
        }
        public static void MarkSupplied(EquipmentRequest request)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update equipment_request set supplied=\"true\" where request_id={request.RequestId}";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }


        private static EquipmentRequest Parse(OleDbDataReader reader)
        {
            int requestId = int.Parse(reader[0].ToString());
            int equipmentId = int.Parse(reader[1].ToString());
            int quantity = int.Parse(reader[2].ToString());
            DateTime dateSent = DateTime.Parse(reader[3].ToString());
            return new EquipmentRequest(requestId, equipmentId, quantity, dateSent);
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


        public static void SendRequest(int equipmentId, int quantity)
        {
            EquipmentRequest request = new EquipmentRequest(equipmentId, quantity);
            Add(request);
        }

        public static List<EquipmentRequest> GetRequestsReadyToSupply()
        {
            List<EquipmentRequest> requests = new List<EquipmentRequest>();
            foreach (EquipmentRequest request in GetAll())
            {
                if (request.DateSent < DateTime.Now.AddDays(-1)) requests.Add(request);
            }
            return requests;
        }


    }
}
