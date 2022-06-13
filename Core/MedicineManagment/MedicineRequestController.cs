using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace HealthCareInfromationSystem.Core.MedicineManagment
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
