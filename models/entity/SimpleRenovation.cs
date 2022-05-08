using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.models.entity
{
    class SimpleRenovation
    {
        private String id;
        private String premiseId;
        private String startDate;
        private String endDate;

        public SimpleRenovation(String renovationId, String premiseId, String startDate, String endDate)
        {
            this.id = renovationId;
            this.premiseId = premiseId;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public string Id { get => id; set => id = value; }
        public string PremiseId { get => premiseId; set => premiseId = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string EndDate { get => endDate; set => endDate = value; }
    }
}
