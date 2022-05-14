using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.users;


namespace HealthCareInfromationSystem.models.entity

{
	class MedicalPrescription
	{
		int _id;
		Medicine _medicine;
		string _quantity;
		Medicine.DrinkingPeriod _timeOfConsumption;
		Person _patient;
		private DateTime _beginning;
		private DateTime _ending;

		public int Id { get => _id; set => _id = value; }
		public Medicine Medicine { get => _medicine; set => _medicine = value; }
		public string Quantity { get => _quantity; set => _quantity = value; }
		public Medicine.DrinkingPeriod TimeOfConsumption { get => _timeOfConsumption; set => _timeOfConsumption = value; }
		public Person Patient { get => _patient; set => _patient = value; }
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
	}
}
