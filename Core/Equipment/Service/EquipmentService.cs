using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.Core.Equipment.Repository;
using HealthCareInfromationSystem.Core.Equipment;
using HealthCareInfromationSystem.repository;

namespace HealthCareInfromationSystem.Core.Equipment.Service
{
	class EquipmentService
	{
		IEquipmentRepo equipmentRepo = new EquipmentSQL();
        IEquipmentRequestRepo requestRepo = new EquipmentRequestSQL();

		public List<Equipment> LoadEquipmentsFromPremise(string premiseId) {
			return equipmentRepo.GetEquipmentFromPremise(premiseId);
		}

		public void SaveToBase(string id, int newQuantity) {
			equipmentRepo.EditQuantity(id, newQuantity);
		}

        public List<Equipment> GetDynamicEquipmentOutOfStock()
        {
            return equipmentRepo.GetDynamicEquipmentOutOfStock();
        }

        public List<Equipment> GetEquipmentLowOnStock(string equipmentName)
        {
            return equipmentRepo.GetEquipmentLowOnStock(equipmentName);
        }

        public List<Equipment> GetEquipmentWithSufficentStock(string equipmentName)
        {
            return equipmentRepo.GetEquipmentWithSufficentStock(equipmentName);
        }

        public List<string> GetDistinctEquipmentNames()
        {
            return equipmentRepo.GetDistinctEquipmentNames();
        }

        public void Move(string equipmentName, string oldPremiseId, string newPremiseId, int quantity)
        {
            Equipment fromOldPremise = equipmentRepo.GetByNameFromPremise(equipmentName, oldPremiseId);
            Equipment fromNewPremise = equipmentRepo.GetByNameFromPremise(equipmentName, newPremiseId);
            equipmentRepo.EditQuantity(fromOldPremise.Id.ToString(), fromOldPremise.Quantity - quantity);
            equipmentRepo.EditQuantity(fromNewPremise.Id.ToString(), fromNewPremise.Quantity + quantity);
        }

        public void SupplyFromReadyRequests()
        {
            foreach (EquipmentRequest request in requestRepo.GetRequestsReadyToSupply())
            {
                equipmentRepo.EditQuantity(request.EquipmentId.ToString(), request.Quantity); // supplies the requested quantity
                requestRepo.SetSuppliedStatus(request);
            }
        }

    }
}
