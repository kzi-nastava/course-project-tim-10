using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.repository;

namespace HealthCareInfromationSystem.Servise
{
	class MedicineRequestService
	{
		IMedicineRepo medicineRepo = new MedicineSQL();

		public List<Medicine> LoadUnverifiedMedicine() {
			return medicineRepo.LoadAll();
		}

		public void Edit(Medicine medicine) {
			medicineRepo.Edit(medicine);
		}
	}
}
