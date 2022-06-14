using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.PremiseManagment.Renovation
{
    class RenovationService
    {
        private IRenovationRepo renovationRepo = new RenovationSQL();
        private IPremisseRepo premiseRepo = new PremisseSQL();

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

        public Dictionary<string, string> LoadPremiseNameAndId()
        {
            return premiseRepo.LoadNameAndId();
        }

        public DataTable LoadEquipmentByPremise(String id)
        {
            return premiseRepo.LoadEquipmentByPremise(id);
        }

        public void SaveComplexRenovation(ComplexRenovation renovation)
        {
            renovationRepo.SaveComplexRenovation(renovation);
        }

        public void SaveCombiningComplexMoving(ComplexMoving moving)
        {
            renovationRepo.SaveCombiningComplexMoving(moving);
        }

        public void SaveDividingComplexMoving(ComplexMoving moving, String equipmentId)
        {
            renovationRepo.SaveDividingComplexMoving(moving, equipmentId);
        }

        public void CheckForComplexRenovationToExecute()
        {
            renovationRepo.CheckForComplexRenovationToExecute();
        }

        public void CheckForComplexMovingToExecute()
        {
            renovationRepo.CheckForComplexMovingToExecute();
        }
    }
}
