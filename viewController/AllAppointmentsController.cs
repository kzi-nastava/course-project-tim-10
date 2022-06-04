using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.view;

namespace HealthCareInfromationSystem.viewController
{
	class AllAppointmentsController
	{
		private AllAppointmentsController view;
		private IAppointmentRepo appointmentRepo;

		public AllAppointmentsController(AllAppointmentsController view, IAppointmentRepo appointmentRepo) {
			this.view = view;
			this.appointmentRepo = appointmentRepo;
			
		}
	}
}
