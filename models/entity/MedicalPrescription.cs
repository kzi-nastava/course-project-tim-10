using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.models.entity

{
	class MedicalPrescription
	{
		int _id;
		Medicine _medicine;
		string _quantity;
		Medicine.DrinkingPeriod _timeOfConsumption;
		private DateTime _timeTaking;
		Person _patient;
		private DateTime _beginning;
		private DateTime _ending;

		public int Id { get => _id; set => _id = value; }
		public Medicine Medicine { get => _medicine; set => _medicine = value; }
		public string Quantity { get => _quantity; set => _quantity = value; }
		public Medicine.DrinkingPeriod TimeOfConsumption { get => _timeOfConsumption; set => _timeOfConsumption = value; }
		public Person Patient { get => _patient; set => _patient = value; }
		public DateTime TimeTaking { get => _timeTaking; set => _timeTaking = value; }
		public DateTime Ending { get => _ending; set => _ending = value; }
		public DateTime Beginning { get => _beginning; set => _beginning = value; }

		public MedicalPrescription() { }

		public MedicalPrescription(int id, Medicine medicine, string quantity, Medicine.DrinkingPeriod timeOfConsumption, Person patient, DateTime beginning, DateTime ending)
		{
			_id = id;
			_medicine = medicine;
			_quantity = quantity;
			_timeOfConsumption = timeOfConsumption;
			_patient = patient;
			_beginning = beginning;
			_ending = ending;
		}

		public MedicalPrescription(int id, Medicine medicine, string quantity, DateTime timeTaking, Person patient, DateTime beginning, DateTime ending)
		{
			_id = id;
			_medicine = medicine;
			_quantity = quantity;
			_timeTaking = timeTaking;
			_patient = patient;
			_beginning = beginning;
			_ending = ending;
		}

		public static MedicalPrescription Parse(OleDbDataReader reader)
		{
			int id = int.Parse(reader[0].ToString());
			Medicine medicine = MedicineController.LoadOneById(reader[1].ToString());
			string quantity = reader[2].ToString();
			DateTime timeTaking = MyConverter.ToTime(reader[3].ToString());
			Person patient = PersonController.SearchPerson(reader[4].ToString());
			DateTime beginning = MyConverter.ToDate(reader[5].ToString());
			DateTime ending = MyConverter.ToDate(reader[6].ToString());
			return new MedicalPrescription(id, medicine, quantity, timeTaking, patient, beginning, ending);
		}
	}
}
