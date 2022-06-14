using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.PremiseManagment.Renovation
{
    class RenovationService
    {
        private IRenovationRepo renovationRepo = new RenovationSQL();

        public List<SimpleRenovation> LoadAllSimpleRenovations()
        {
            return renovationRepo.LoadAllSimpleRenovations();
        }

        public void SaveSimpleRenovation(SimpleRenovation renovation)
        {
            renovationRepo.SaveSimpleRenovation(renovation);
        }

        public bool CheckIfSimpleRenovationExistsById(string id)
        {
            return renovationRepo.CheckIfSimpleRenovationExistsById(id);
        }
    }
}
