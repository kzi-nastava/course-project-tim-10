using System.Collections.Generic;
 
using HealthCareInfromationSystem.Core.User;
using HealthCareInfromationSystem.Core.MedicineManagment;

namespace HealthCareInfromationSystem.Core.MedicalRecord
{
    class MedicalRecordController
	{
		MedicalRecordService medicalRecordService = new MedicalRecordService();
		public MedicalRecord GetMedicalRecordByPatient(string patientId)
		{
			return medicalRecordService.GetMedicalRecordByPatient(patientId);
		}
		public void Edit(MedicalRecord medicalRecord)
		{
			medicalRecordService.Edit(medicalRecord);
		}

		public Dictionary<string, string> LoadFullNameAndId(string role)
		{
			return medicalRecordService.LoadFullNameAndId(role);
		}
		public Person GetPersonById(string id)
		{
			return medicalRecordService.GetPersonById(id);
		}

		public List<string> LoadSpecialisations()
		{
			return medicalRecordService.LoadSpecialisations();
		}
		public void Add(string patientId, string specialisation, string doctorId)
		{
			medicalRecordService.Add(patientId, specialisation, doctorId);
		}

		public Dictionary<string, string> LoadMedicineNameAndId()
		{
			return medicalRecordService.LoadMedicineNameAndId();
		}

		public Medicine GetMedicine(string id)
		{
			return medicalRecordService.GetMedicine(id);
		}

		public void Add(MedicalPrescription.MedicalPrescription prescription)
		{
			medicalRecordService.Add(prescription);
		}
	}
}
