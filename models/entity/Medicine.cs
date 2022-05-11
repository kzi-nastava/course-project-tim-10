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
		private int _id;
		private string _name;
		private string _description;
		private string[] _ingredients;
		private bool _isVerified;

		Medicine() { }

		Medicine(int id, string name, string description, string[] ingredients, bool isVerified)
		{
			_id = id;
			_name = name;
			_description = description;
			_ingredients = ingredients;
			IsVerified = isVerified;
		}

		public int Id { get => _id; set => _id = value; }
		public string Name { get => _name; set => _name = value; }
		public string Description { get => _description; set => _description = value; }
		public string[] Ingredients { get => _ingredients; set => _ingredients = value; }
		public bool IsVerified { get => _isVerified; set => _isVerified = value; }

		public static Medicine Parse(OleDbDataReader reader) {
			int id = int.Parse(reader[0].ToString());
			string name = reader[1].ToString();
			string description = reader[2].ToString();
			string[] ingredients = ParseIngredientds(reader[3].ToString());
			bool isValid = Convert.ToBoolean(reader[4].ToString());
			return new Medicine(id, name, description, ingredients, isValid);
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
