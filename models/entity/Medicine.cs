using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace HealthCareInfromationSystem.models.entity

{
	public class Medicine
	{

		public enum DrinkingPeriod { 
			NotImportant, 
			BeforeLunch, 
			DuringLunch, 
			AfterLunch

		}
		private int _id;
		private string _name;
		private string _description;
		private string[] _ingredients;
		private string _status;
		private string _comment;

		Medicine() { }

		public Medicine(int id, string name, string description, string[] ingredients, string status, string comment)
		{
			_id = id;
			_name = name;
			_description = description;
			_ingredients = ingredients;
			_status = status;
			_comment = comment;
		}

		

		public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string[] Ingredients { get => _ingredients; set => _ingredients = value; }
        public string Status { get => _status; set => _status = value; }
        public string Comment { get => _comment; set => _comment = value; }
		
		public static Medicine Parse(OleDbDataReader reader) {
			int id = int.Parse(reader[0].ToString());
			string name = reader[1].ToString();
			string description = reader[2].ToString();
			string[] ingredients = ParseIngredientds(reader[3].ToString());
			string status = reader[4].ToString();
			string comment = reader[5].ToString();
			return new Medicine(id, name, description, ingredients, status, comment);
		}

		private static string[] ParseIngredientds(string ingredients)
		{
			string[] allIngredients = ingredients.Split(',');
			for (int i = 0; i < allIngredients.Length; i++) {
				allIngredients[i] = allIngredients[i].Trim();
			}
			return allIngredients;
		}
	}
}
