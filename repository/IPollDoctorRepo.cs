using HealthCareInfromationSystem.models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.repository
{
    interface IPollDoctorRepo
    {
		void Add(PollDoctor pollDoctor);
		void Edit(PollDoctor pollDoctor);
		List<PollDoctor> LoadAll();

	}
}
