using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.models.users
{
    class Secretary : Person
    {

        public Secretary() : base() { }

        public Secretary(int id, string name, string lastName, Role role,
					  string password, bool blocked, int blocker, string username) : base(id, name, lastName, role,
                          password, blocked, blocker, username) { }

}
}
