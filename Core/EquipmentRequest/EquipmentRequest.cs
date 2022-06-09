using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.EquipmentRequest
{
    class EquipmentRequest
    {
        private int requestId;
        private int quantity;
        private int equipmentId;
        private DateTime dateSent;
        public int RequestId { get => requestId; set => requestId = value;  }
        public int Quantity { get => quantity; set => quantity = value; }
        public int EquipmentId { get => equipmentId; set => equipmentId = value; }
        public DateTime DateSent { get => dateSent; set => dateSent = value; }
        public EquipmentRequest(int requestId, int id, int quantity, DateTime dateSent)
        {
            this.requestId = requestId;
            this.equipmentId = id;
            this.quantity = quantity;
            this.dateSent = dateSent;
        }

        public EquipmentRequest(int equipmentId, int quantity)
        {
            this.equipmentId = equipmentId;
            this.quantity = quantity;
            this.dateSent = DateTime.Now;
        }

    }
}
