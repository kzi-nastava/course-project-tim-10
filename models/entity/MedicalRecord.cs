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

		public int GetId()
		{
			return id;
		}

		public double GetHeight()
		{
			return height;
		}



		public double GetWeight()
		{
			return weight;
		}

		public string GetDisease()
		{
			return disease;
		}

		public string GetAlergies()
		{
			return alergies;
		}

		public BloodType GetBloodType()
		{
			return bloodType;
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
	}
}