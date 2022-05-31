using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.models.entity
{
	class Equipment
	{
        private String name;
        private int quantity;
        private int id;

		public Equipment(string name, int quantity, int id)
		{

			this.name = name;
			this.quantity = quantity;
			this.Id = id;
		}

		public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
		public int Id { get => id; set => id = value; }

		internal static Equipment Parse(OleDbDataReader reader)
		{
			int id = int.Parse(reader[2].ToString());
			int quantity = int.Parse(reader[1].ToString());
            string name = reader[0].ToString();
            return new Equipment(name, quantity, id);
        }
	}
}
