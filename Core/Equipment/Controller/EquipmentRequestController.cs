using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.Core.Equipment.Service;

namespace HealthCareInfromationSystem.Core.Equipment.Controller
{
    class EquipmentRequestController
    {
        private EquipmentRequestService equipmentRequestService = new EquipmentRequestService();
        public void SendRequest(int equipmentId, int quantity)
        {
            equipmentRequestService.SendRequest(equipmentId, quantity);
        }



    }
}
