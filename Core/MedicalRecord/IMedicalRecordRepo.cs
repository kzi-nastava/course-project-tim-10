using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.Core.MedicalRecord
{
	interface IMedicalRecordRepo
	{
		MedicalRecord GetMedicalRecordByPatient(string patientId);
		void Edit(MedicalRecord medicalRecord);
		void AddNewByPatientId(string id);
		void DeleteByPatientId(string id);
	}
}
