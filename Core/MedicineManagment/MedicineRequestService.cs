using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using HealthCareInfromationSystem.repository;

namespace HealthCareInfromationSystem.Core.MedicineManagment
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

		public void Save(Medicine medicine)
        {
			medicineRepo.Save(medicine);
        }

		public List<Medicine> LoadDenied()
        {
			return medicineRepo.LoadDenied();
        }
	}
}
