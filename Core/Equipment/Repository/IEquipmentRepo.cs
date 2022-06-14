using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace HealthCareInfromationSystem.Core.Equipment.Repository
{
	interface IEquipmentRepo
	{
		List<Equipment> GetEquipmentFromPremise(string premiseId);
		void EditQuantity(string id, int newQuantity);
		Equipment GetByNameFromPremise(string name, string premiseId);
		List<Equipment> GetDynamicEquipment();
		List<Equipment> GetDynamicEquipmentOutOfStock();
		List<Equipment> GetEquipmentLowOnStock(string equipmentName);
		List<Equipment> GetEquipmentWithSufficentStock(string equipmentName);
		List<string> GetDistinctEquipmentNames();
		DataTable LoadAll();
		void Transfer(string id, string newPremiseId, string date);
	}
}
