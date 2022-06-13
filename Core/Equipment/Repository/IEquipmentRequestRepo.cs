using HealthCareInfromationSystem.Core.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Equipment.Repository
{
    interface IEquipmentRequestRepo
    {
        void Add(EquipmentRequest request);

        List<EquipmentRequest> GetAll();

        void SetSuppliedStatus(EquipmentRequest request);

        List<EquipmentRequest> GetRequestsReadyToSupply();
    }
}
