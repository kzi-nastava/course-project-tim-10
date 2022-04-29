using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.models.entity
{
    public class Premise
    {
        private String id;
        private String name;
        private String type;

        public Premise(string id, string name, string type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }

        public static Premise Parse(OleDbDataReader reader)
        {
            string id = reader[0].ToString();
            string name = reader[1].ToString();
            string type = reader[2].ToString();
            return new Premise(id, name, type);
        }
    }
}
