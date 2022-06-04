using HealthCareInfromationSystem.models.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.repository.users
{
    interface IPatientRepo
    {
        void Add(Person patient);
        void Edit(Person patient);
        void Delete(Person patient);
        bool IfExistsById(string id);
        bool IfExistsByUsername(string username);
        List<Person> GetAll();
        List<Person> GetBlockedPatients();
    }
}
