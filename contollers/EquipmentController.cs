using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.Servise;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.contollers
{
    class EquipmentController
    {
        private EquipmentService equipmentService = new EquipmentService();

        public List<Equipment> GetDynamicEquipmentOutOfStock()
        {
            return equipmentService.GetDynamicEquipmentOutOfStock();
        }

        public void SupplyFromReadyRequests()
        {
            equipmentService.SupplyFromReadyRequests();
        }

        public List<string> GetEquipmentNames()
        {
            return equipmentService.GetDistinctEquipmentNames();
        }

        public List<List<string>> GetRowsForEquipmentLowOnStock(string equipmentName)
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (Equipment equipment in equipmentService.GetEquipmentLowOnStock(equipmentName))
            {
                rows.Add(GetTableRow(equipment));
                
            }
            return rows;
        }

        public List<List<string>> GetRowsForEquipmentWithSufficentStock(string equipmentName)
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (Equipment equipment in equipmentService.GetEquipmentWithSufficentStock(equipmentName))
            {
                rows.Add(GetTableRow(equipment));

            }
            return rows;
        }

        private static List<string> GetTableRow(Equipment equipment)
        {
            List<string> row = new List<string>();
            if (equipment.Quantity == 0) row.Add("Out Of Stock!");
            else row.Add("");
            row.Add(equipment.Id.ToString());
            row.Add(equipment.Premise.Id.ToString());
            row.Add(equipment.Premise.Name);
            row.Add(equipment.Quantity.ToString());
            return row;
        }

        public void Move(string equipmentName, string oldPremiseId, string newPremiseId, int quantity)
        {
            equipmentService.Move(equipmentName, oldPremiseId, newPremiseId, quantity);
        }

    }
}
