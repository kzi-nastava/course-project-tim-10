using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.PremiseManagment.Renovation
{
    interface IRenovationRepo
    {
        List<SimpleRenovation> LoadAllSimpleRenovations();
        void SaveSimpleRenovation(SimpleRenovation renovation);
        bool CheckIfSimpleRenovationExistsById(string id);


        void SaveComplexRenovation(ComplexRenovation renovation);
        void SaveCombiningComplexMoving(ComplexMoving moving);
        void SaveDividingComplexMoving(ComplexMoving moving, String equipmentId);

        void CheckForComplexRenovationToExecute();
        void CheckForComplexMovingToExecute();
    }
}
