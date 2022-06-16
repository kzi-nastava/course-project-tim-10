 
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
			int count = 0;

			foreach (PollDoctor pollDoctor in pollDoctorRepo.LoadAll())
			{
				if (pollDoctor.Doctor.Id.ToString() == doctorId && pollDoctor.Quality.ToString() == mark)
					count++;
				if (pollDoctor.Doctor.Id.ToString() == doctorId && pollDoctor.Recommendation.ToString() == mark)
					count++;
			}

			return count.ToString();
		}

		public String GetAverageMarkForDoctor(String doctorId)
		{
			float count = 0;
			int numOfPolls = 0;

			foreach (PollDoctor pollDoctor in pollDoctorRepo.LoadAll())
				if (pollDoctor.Doctor.Id.ToString() == doctorId)
				{
					count += pollDoctor.Quality + pollDoctor.Recommendation;
					numOfPolls++;
				}

			return numOfPolls == 0 ? "0" : (count / (numOfPolls * 2)).ToString();
		}

		public String GetDoctorPollStatistics()
		{
			String text = "";
			foreach (Person doctor in personRepo.LoadAllDoctors())
            {
				String id = doctor.Id.ToString();

				text += $"{doctor.FirstName} {doctor.LastName}: Average quality ({pollDoctorRepo.GetAverageForDoctorPollItem("quality", id)}), recommendation ({pollDoctorRepo.GetAverageForDoctorPollItem("recommendation", id)}). ";

				text += $"(mark, number of marks): ";

				for (int i = 1; i < 6; i++)
                {
					text += $"({i}, {GetCountOfMarksForDoctorItem(i.ToString(), id)}) ";
                }

				text += $"Average mark: {GetAverageMarkForDoctor(id)} \n";
			}

			return text;
		}

		public List<KeyValuePair<Person, float>> GetDoctorsWithAverageMarks()
        {
			Dictionary<Person, float> averageMarks = new Dictionary<Person, float>();

			foreach (Person doctor in personRepo.LoadAllDoctors())
				averageMarks.Add(doctor, float.Parse(GetAverageMarkForDoctor(doctor.Id.ToString())));

			List<KeyValuePair<Person, float>> doctorsWithAverageMarks = new List<KeyValuePair<Person, float>>(averageMarks);

			doctorsWithAverageMarks.Sort((x, y) => x.Value.CompareTo(y.Value));
			doctorsWithAverageMarks.Reverse();

			return doctorsWithAverageMarks;
        }
	}
}
