using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;

using HealthCareInfromationSystem.repository;

namespace HealthCareInfromationSystem.Servise
{
	class MedicalRecordService
	{
		IMedicalRecordRepo medicalRecordRepo = new MedicalRecordSQL();
		IPersonRepo personRepo = new PersonSQL();
		IReferealLeterRepo referealLeterRepo = new ReferralLeterSQL();
		ISpecialisationRepo specialisationRepo = new SpecialisationSQL();
		IMedicineRepo medicineRepo = new MedicineSQL();
		IPrescriptionRepo prescriptionRepo = new PrescriptionSQL();

		public MedicalRecord GetMedicalRecordByPatient(string patientId) {
			return medicalRecordRepo.GetMedicalRecordByPatient(patientId);
		}
		public void EditInBase(MedicalRecord medicalRecord) {
			medicalRecordRepo.Edit(medicalRecord);
		}

		public Dictionary<string, string> LoadFullNameAndId(string role) {
			return personRepo.LoadFullNameAndId(role);
		}
		public Person GetPersonById(string id)
		{
			return personRepo.LoadOnePerson(id);
		}

		public List<string> LoadSpecialisations() {
			return specialisationRepo.LoadSpecialisations();
		}
		public void AddToBase(string patientId, string specialisation, string doctorId) {
			referealLeterRepo.Add(patientId, specialisation, doctorId);
		}

		public Dictionary<string, string> LoadMedicineNameAndId() {
			return medicineRepo.LoadNameAndId();
		}

		public Medicine GetMedicine(string id) {
			return medicineRepo.LoadOneById(id);
		}

		public void SaveToBase(MedicalPrescription prescription) {
			prescriptionRepo.Add(prescription);
		}
	}
}
