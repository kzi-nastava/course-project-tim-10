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
	class MedicalPrescriptionController
	{
        public void SaveToBase(MedicalPrescription medicalPrescription)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"insert into medical_prescriiption values (\"{medicalPrescription.Id}\", \"{medicalPrescription.Medicine.Id}\", " +
                                                                         $"\"{medicalPrescription.Quantity}\", \"{medicalPrescription.TimeOfConsumption}\", " +
                                                                         $"\"{medicalPrescription.Patient.Id}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
