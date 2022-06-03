using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.repository
{
	interface IEquipmentRepo
	{
		List<Equipment> LoadEquipmentsFromPremise(string premiseId);
		void Add(string id, int newQuantity);
	}
}
