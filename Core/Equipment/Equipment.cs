using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Equipment
{
	class Equipment
	{
        private String name;
        private int quantity;
        private int id;
		private Premise premise;

		public Equipment(string name, int quantity, int id)
		{

			this.name = name;
			this.quantity = quantity;
			this.Id = id;
		}

		public Equipment(string name, int quantity, int id, Premise premise)
        {
			this.name = name;
			this.quantity = quantity;
			this.id = id;
			this.premise = premise;
		}

		public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
		public int Id { get => id; set => id = value; }
		public Premise Premise { get => premise; set => premise = value; }

		internal static Equipment Parse(OleDbDataReader reader)
		{
			int id = int.Parse(reader[2].ToString());
			int quantity = int.Parse(reader[1].ToString());
            string name = reader[0].ToString();
            return new Equipment(name, quantity, id);
        }

		internal static Equipment ParseWithPremise(OleDbDataReader reader)
        {
			string name = reader[0].ToString();
			int quantity = int.Parse(reader[1].ToString());
			int id = int.Parse(reader[2].ToString());
			Premise premise = PremiseController.GetPremiseById(reader[3].ToString());
			return new Equipment(name, quantity, id, premise);
		}
	}
}
