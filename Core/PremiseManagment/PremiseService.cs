using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.PremiseManagment
{
    class PremiseService
    {
        IPremisseRepo premiseRepo = new PremisseSQL();

        public bool CheckIfPremiseExistsById(String id)
        {
            return premiseRepo.CheckIfPremiseExistsById(id);
        }

        public bool CheckIfPremiseIsOccupied(String id, String startDate, String endDate)
        {
            return premiseRepo.CheckIfPremiseIsOccupied(id, startDate, endDate);
        }

        public void SimpleDeletePremise(String id)
        {
            premiseRepo.SimpleDeletePremise(id);
        }

        public void Delete(string id)
        {
            premiseRepo.Delete(id);
        }

        public void Edit(Premise premise)
        {
            premiseRepo.Edit(premise);
        }

        public void Save(Premise premise)
        {
            premiseRepo.Save(premise);
        }

        public List<Premise> LoadAll()
        {
            return premiseRepo.LoadAll();
        }
    }
}
