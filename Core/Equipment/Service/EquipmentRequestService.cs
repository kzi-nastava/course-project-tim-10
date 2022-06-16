using HealthCareInfromationSystem.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.Core.Equipment;
using HealthCareInfromationSystem.Core.Equipment.Repository;

namespace HealthCareInfromationSystem.Core.Equipment.Service
{
    class EquipmentRequestService
    {
        private IEquipmentRequestRepo requestRepo = new EquipmentRequestSQL();

        public void SendRequest(int equipmentId, int quantity)
        {
            EquipmentRequest request = new EquipmentRequest(equipmentId, quantity);
            requestRepo.Add(request);
        }
    }
}
