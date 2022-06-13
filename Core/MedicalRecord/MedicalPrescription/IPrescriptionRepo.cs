using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace HealthCareInfromationSystem.Core.MedicalRecord.MedicalPrescription
{
	interface IPrescriptionRepo
	{
		void Add(MedicalPrescription medicalPrescription);
	}
}
