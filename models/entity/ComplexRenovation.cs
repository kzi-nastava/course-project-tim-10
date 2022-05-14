using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.models.entity
{
    class ComplexRenovation
    {
        private Premise premise;
        private String flag;
        private String move_date;

        public ComplexRenovation(Premise premise, string flag, string move_date)
        {
            this.premise = premise;
            this.flag = flag;
            this.move_date = move_date;
        }

        public Premise Premise { get => premise; set => premise = value; }
        public string Flag { get => flag; set => flag = value; }
        public string Move_date { get => move_date; set => move_date = value; }
    }
}
