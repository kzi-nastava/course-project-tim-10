using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.models.entity
{
	public enum BloodType
	{
		A,
		B,
		AB,
		O
	}
	public class MedicalRecord
	{
		int id;
		double height;
		double weight;
		BloodType bloodType;
		string disease;
		string alergies;

		public int Id { get => id; set => id = value; }
		public double Height { get => height; set => height = value; }
		public double Weight { get => weight; set => weight = value; }
		public BloodType BloodType { get => bloodType; set => bloodType = value; }
		public string Disease { get => disease; set => disease = value; }
		public string Alergies { get => alergies; set => alergies = value; }

		public MedicalRecord()
		{
		}

		public MedicalRecord(int id, double height, double weight,
			BloodType bloodType, string disease, string alergies)
		{
			this.id = id;
			this.height = height;
			this.weight = weight;
			this.bloodType = bloodType;
			this.disease = disease;
			this.alergies = alergies;
		}


		internal static MedicalRecord Parse(OleDbDataReader reader)
		{
			int id = int.Parse(reader[0].ToString());
			double height = double.Parse(reader[1].ToString());
			double weight = double.Parse(reader[2].ToString());
			Enum.TryParse(reader[3].ToString(), out BloodType bloodType);
			string disease = reader[4].ToString();
			string alergie = reader[5].ToString();

			return new MedicalRecord(id, height, weight, bloodType, disease, alergie);
		}

		internal bool IsAlergic(string[] ingredients)
		{
			string[] allAlergies = alergies.Split(',');
			foreach (string alergie in allAlergies) {
				if (ingredients.Contains(alergie.Trim())) return true;
			}
			return false;
		}
	}
}