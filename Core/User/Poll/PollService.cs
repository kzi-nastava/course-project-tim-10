 
using HealthCareInfromationSystem.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.User.Poll
{
    class PollService
    {
        readonly IPollDoctorRepo pollDoctorRepo = new PollDoctorSQL();
		readonly IPollHospitalRepo pollHospitalRepo = new PollHospitalSQL();
		private IPersonRepo personRepo = new PersonSQL();

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

		public String GetAverageForHospitalPollItem(String item)
        {
			return pollHospitalRepo.GetAverageForHospitalPollItem(item);
        }

		public String GetCountOfMarksForHospitalItem(String mark, String item)
        {
			return pollHospitalRepo.GetCountOfMarksForHospitalItem(mark, item);
        }

		public String GetCountOfMarksForDoctorItem(String mark, String doctorId)
		{
			int ret = 0;

			foreach (PollDoctor pollDoctor in pollDoctorRepo.LoadAll())
			{
				if (pollDoctor.Doctor.Id.ToString() == doctorId && pollDoctor.Quality.ToString() == mark)
					ret++;
				if (pollDoctor.Doctor.Id.ToString() == doctorId && pollDoctor.Recommendation.ToString() == mark)
					ret++;
			}

			return ret.ToString();
		}

		public String GetAverageMarkForDoctor(String doctorId)
		{
			float ret = 0;
			int numOfPolls = 0;

			foreach (PollDoctor pollDoctor in pollDoctorRepo.LoadAll())
				if (pollDoctor.Doctor.Id.ToString() == doctorId)
				{
					ret += pollDoctor.Quality + pollDoctor.Recommendation;
					numOfPolls++;
				}

			return numOfPolls == 0 ? "0" : (ret / (numOfPolls * 2)).ToString();
		}

		public String GetDoctorPollStatistics()
		{
			String ret = "";
			foreach (Person doctor in personRepo.LoadAllDoctors())
            {
				String id = doctor.Id.ToString();

				ret += $"{doctor.FirstName} {doctor.LastName}: Average quality ({pollDoctorRepo.GetAverageForDoctorPollItem("quality", id)}), recommendation ({pollDoctorRepo.GetAverageForDoctorPollItem("recommendation", id)}). ";

				ret += $"(mark, number of marks): ";

				for (int i = 1; i < 6; i++)
                {
					ret += $"({i}, {GetCountOfMarksForDoctorItem(i.ToString(), id)}) ";
                }

				ret += $"Average mark: {GetAverageMarkForDoctor(id)} \n";
			}

			return ret;
		}
	}
}
