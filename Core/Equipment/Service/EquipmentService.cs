using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.Core.Equipment.Repository;
using HealthCareInfromationSystem.Core.Equipment;
using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.Core.PremiseManagment;
using System.Data.OleDb;
using System.Data;

namespace HealthCareInfromationSystem.Core.Equipment.Service
{
	class EquipmentService
	{
		IEquipmentRepo equipmentRepo = new EquipmentSQL();
        IEquipmentRequestRepo requestRepo = new EquipmentRequestSQL();
        IPremisseRepo premiseRepo = new PremisseSQL();

        public DataTable SearchByTerm(string term)
        {
            return equipmentRepo.SearchByTerm(term);
        }

        public DataTable SearchByCriteria(string premisesType, string quantity, string equipmentType)
        {
            String premisesTypeQuery = premisesType == "" ? "" : $"(pr1.type=\"{premisesType}\" or pr2.type=\"{premisesType}\")";

            String quantityQuery = "";
            if (quantity == "") quantityQuery = "";
            else if (quantity == "out of stock") quantityQuery = "eq.quantity=0";
            else if (quantity == "0-10") quantityQuery = "(eq.quantity > 0 and eq.quantity <= 10)";
            else if (quantity == "10+") quantityQuery = "eq.quantity > 10";

            String equipmentTypeQuery = equipmentType == "" ? "" : $"eq.type=\"{equipmentType}\"";

            String query = $"" +
                $"select eq.equipment_id, eq.name, eq.quantity, eq.type, pr1.name as old_premise, pr2.name as new_premise, eq.move_date as move_date " +
                $"from equipment as eq, premises as pr1, premises as pr2 " +
                $"where eq.old_premises_id=pr1.premises_id and eq.new_premises_id=pr2.premises_id";

            if (premisesTypeQuery != "") query += $" and {premisesTypeQuery}";
            if (quantityQuery != "") query += $" and {quantityQuery}";
            if (equipmentTypeQuery != "") query += $" and {equipmentTypeQuery}";

            return equipmentRepo.SearchByCriteria(query);
        }

        public Dictionary<string, string> LoadPremiseNameAndId()
        {
            return premiseRepo.LoadNameAndId();
        }

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

        public DataTable LoadAll()
        {
            return equipmentRepo.LoadAll();
        }

        public void Transfer(string id, string newPremiseId, string date)
        {
            equipmentRepo.Transfer(id, newPremiseId, date);
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
