using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.DoctorView
{
	interface IAllApointments
	{
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler CancelEvent;
        //Methods
        void SetPetListBindingSource(BindingSource petList);
        void Show();
    }
}
