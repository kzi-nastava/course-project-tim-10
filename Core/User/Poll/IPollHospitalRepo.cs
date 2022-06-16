 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.User.Poll
{
    interface IPollHospitalRepo
    {
        void Add(PollHospital pollHospital);
        void Edit(PollHospital pollHospital);
        List<PollHospital> LoadAll();
        String GetAverageForHospitalPollItem(String item);
        String GetCountOfMarksForHospitalItem(String mark, String item);

    }
}
