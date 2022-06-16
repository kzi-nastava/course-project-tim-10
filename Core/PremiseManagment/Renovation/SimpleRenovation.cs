using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.PremiseManagment.Renovation
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

        public static SimpleRenovation Parse(OleDbDataReader reader)
        {
            string id = reader[0].ToString();
            string premiseId = reader[1].ToString();
            string startDate = reader[2].ToString();
            string endDate = reader[3].ToString();
            return new SimpleRenovation(id, premiseId, startDate, endDate);
        }
    }
}
