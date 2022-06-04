using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.repository.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Servise
{
    class PatientService
    {
        private IPatientRepo patientRepository = new PatientSQL();
        private IPersonRepo personRepository = new PersonSQL();

        public void Unblock(string patientId)
        {
            Person patient = personRepository.LoadOnePerson(patientId);
            patient.Blocked = false;
            patient.Blocker = 0;
            patientRepository.Edit(patient);
        }

        public List<Person> GetAll()
        {
            return patientRepository.GetAll();
        }
        public List<Person> GetBlockedPatients()
        {
            return patientRepository.GetBlockedPatients();
        }
        public bool IfExistsById(string id)
        {
            return patientRepository.IfExistsById(id);
        }
        public bool IfExistsByUsername(string username)
        {
            return patientRepository.IfExistsByUsername(username);
        }

    }
}
