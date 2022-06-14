 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.User.Poll
{
    interface IPollDoctorRepo
    {
		void Add(PollDoctor pollDoctor);
		void Edit(PollDoctor pollDoctor);
		List<PollDoctor> LoadAll();
		String GetAverageForDoctorPollItem(String item, String doctorId);
		String GetCountOfMarksForDoctorItem(String mark, String item, String doctorId);

	}
}
