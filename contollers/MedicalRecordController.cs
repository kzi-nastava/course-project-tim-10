﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.contollers
{
	class MedicalRecordController
	{
        internal static MedicalRecord LoadMedical(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    return MedicalRecord.Parse(reader);
                }
                reader.Close();
                return null;
            }
        }

		internal static void EditInBase(MedicalRecord medicalRecord)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update medical_record set height=\"{medicalRecord.Height}\", weight=\"{medicalRecord.Weight}\", " +
                    $"bloodType=\"{medicalRecord.BloodType}\", disease=\"{medicalRecord.Disease}\", alergies=\"{medicalRecord.Alergies}\" where id=\"{medicalRecord.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void AddNewByPatientId(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into medical_record (id, patientId) values (\"{id}\", \"{id}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }

        public static void DeleteByPatientId(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"delete from medical_record where patientId=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }

    }
}
