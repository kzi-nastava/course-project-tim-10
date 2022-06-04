using HealthCareInfromationSystem.models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.repository
{
    interface IEquipmentRequestRepo
    {
        void Add(EquipmentRequest request);

        List<EquipmentRequest> GetAll();

        void SetSuppliedStatus(EquipmentRequest request);

        List<EquipmentRequest> GetRequestsReadyToSupply();
    }
}
