using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.models.entity
{
    class EquipmentRequest
    {
        private int quantity;
        private int equipmentId;
        private DateTime dateSent;
        public int Quantity { get => quantity; set => quantity = value; }
        public int EquipmentId { get => equipmentId; set => equipmentId = value; }
        public DateTime DateSent { get => dateSent; set => dateSent = value; }
        public EquipmentRequest(int id, int quantity, DateTime dateSent)
        {
            this.equipmentId = id;
            this.quantity = quantity;
            this.dateSent = dateSent;
        }

        public EquipmentRequest(int id, int quantity)
        {
            this.equipmentId = id;
            this.quantity = quantity;
            this.dateSent = DateTime.Now;
        }

    }
}
