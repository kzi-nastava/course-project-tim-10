using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.repository
{
	interface IPremisseRepo
	{
		void Save(Premise premise);
		void Edit(Premise premise);
		void Delete(String id);
		Dictionary<string, string> LoadNameAndId();
		Premise GetPremiseById(string id);
	}
}
