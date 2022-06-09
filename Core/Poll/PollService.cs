using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Poll
{
    class PollService
    {
        readonly IPollDoctorRepo pollDoctorRepo = new PollDoctorSQL();
		readonly IPollHospitalRepo pollHospitalRepo = new PollHospitalSQL();

		public void AddPollDoctor(PollDoctor pollDoctor)
		{
			pollDoctorRepo.Add(pollDoctor);
		}

		public void EditPollDoctor(PollDoctor pollDoctor)
		{
			pollDoctorRepo.Edit(pollDoctor);
		}

		public List<PollDoctor> LoadAllPollsDoctor()
		{
			return pollDoctorRepo.LoadAll();
		}

		public void AddPollHospital(PollHospital pollHospital)
		{
			pollHospitalRepo.Add(pollHospital);
		}

		public void EditPollHospital(PollHospital pollHospital)
		{
			pollHospitalRepo.Edit(pollHospital);
		}

		public List<PollHospital> LoadAllPollsHospital()
		{
			return pollHospitalRepo.LoadAll();
		}


	}
}
