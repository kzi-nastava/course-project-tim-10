using HealthCareInfromationSystem.models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Poll
{
    interface IPollHospitalRepo
    {
        void Add(PollHospital pollHospital);
        void Edit(PollHospital pollHospital);
        List<PollHospital> LoadAll();

    }
}
