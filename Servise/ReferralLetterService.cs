using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Servise
{
    class ReferralLetterService
    {
        private IReferralLetterRepo repository = new ReferralLetterSQL();

        public ReferralLetter GetById(string id)
        {
           return repository.GetById(id);
        }

        public void SetUsedTrue(ReferralLetter referral)
        {
            repository.SetUsedTrue(referral);
        }

        public List<ReferralLetter> GetUnusedForPatient(string patientId)
        {
            return repository.GetUnusedForPatient(patientId);
        }
        
    }
}
