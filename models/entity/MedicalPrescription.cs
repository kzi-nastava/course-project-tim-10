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
		string quantity;
		Medicine.DrinkingPeriod _timeOfConsumption;
		Person patient;

		public int Id { get => _id; set => _id = value; }
		public Medicine Medicine { get => _medicine; set => _medicine = value; }
		public string Quantity { get => quantity; set => quantity = value; }
		public Medicine.DrinkingPeriod TimeOfConsumption { get => _timeOfConsumption; set => _timeOfConsumption = value; }
		public Person Patient { get => patient; set => patient = value; }
	}
}
