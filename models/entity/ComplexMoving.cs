using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.models.entity
{
    class ComplexMoving
    {
        private String id1;
        private String id2;
        private String id3;
        private String flag;
        private String move_date;

        public ComplexMoving(string id1, string id2, string id3, string flag, string move_date)
        {
            this.id1 = id1;
            this.id2 = id2;
            this.id3 = id3;
            this.flag = flag;
            this.move_date = move_date;
        }

        public string Id1 { get => id1; set => id1 = value; }
        public string Id2 { get => id2; set => id2 = value; }
        public string Id3 { get => id3; set => id3 = value; }
        public string Flag { get => flag; set => flag = value; }
        public string Move_date { get => move_date; set => move_date = value; }
    }
}
