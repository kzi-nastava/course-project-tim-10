using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.Servise;

namespace HealthCareInfromationSystem.doctorController
{
	class MedicineRequestController
	{
		MedicineRequestService medicineRequestService = new MedicineRequestService();
		public List<Medicine> LoadUnverifiedMedicine()
		{
			return medicineRequestService.LoadUnverifiedMedicine();
		}

		public void Edit(Medicine medicine)
		{
			medicineRequestService.Edit(medicine);
		}
	}
}
