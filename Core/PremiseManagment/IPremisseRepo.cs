using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace HealthCareInfromationSystem.Core.PremiseManagment
{
	interface IPremisseRepo
	{
		void Save(Premise premise);
		void Edit(Premise premise);
		void Delete(String id);
		Dictionary<string, string> LoadNameAndId();
		Premise GetPremiseById(string id);
		bool CheckIfPremiseExistsById(String id);
		bool CheckIfPremiseIsOccupied(String id, String startDate, String endDate);
		void SimpleDeletePremise(String id);
		List<Premise> LoadAll();
		DataTable LoadEquipmentByPremise(String id);
	}
}
