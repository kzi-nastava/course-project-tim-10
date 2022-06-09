using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.EquipmentRequest
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
