using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.models.entity
{
    class SimpleRenovation
    {
        private String renovationId;
        private String premiseId;
        private String startDate;
        private String endDate;

        public SimpleRenovation(String renovationId, String premiseId, String startDate, String endDate)
        {
            this.renovationId = renovationId;
            this.premiseId = premiseId;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public string RenovationId { get => renovationId; set => renovationId = value; }
        public string PremiseId { get => premiseId; set => premiseId = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string EndDate { get => endDate; set => endDate = value; }
    }
}
