using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class EquipmentStateForm : Form
	{
		private Premise premise;

		public EquipmentStateForm()
		{
			InitializeComponent();
		}

		public EquipmentStateForm(Premise premise)
		{
			this.premise = premise;
		}
	}
}
