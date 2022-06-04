using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.repository;

namespace HealthCareInfromationSystem.Servise
{
	class EquipmentService
	{
		IEquipmentRepo equipmentRepo = new EquipmentSQL();

		public List<Equipment> LoadEquipmentsFromPremise(string premiseId) {
			return equipmentRepo.LoadEquipmentsFromPremise(premiseId);
		}

		public void Add(string id, int newQuantity) {
			equipmentRepo.Save(id, newQuantity);
		}
	}
}
