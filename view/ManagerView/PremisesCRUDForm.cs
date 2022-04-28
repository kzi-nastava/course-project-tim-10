using HealthCareInfromationSystem.contollers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.ManagerView
{
    public partial class PremisesCRUDForm : Form
    {
        private PremiseController premiseController = new PremiseController();

        public PremisesCRUDForm()
        {
            InitializeComponent();
        }

        private void SetLabelsAndButtons()
        {
            label1.Text = "Premise ID";
            label2.Text = "Name";
            label3.Text = "Premise type";
            label4.Text = "";
            button1.Text = "Add new";
            button2.Text = "Edit";
            button3.Text = "Delete";
            button4.Text = "Clear";
        }

        private void FillComboBox()
        {
            comboBox1.Items.Add("operational room");
            comboBox1.Items.Add("examination room");
            comboBox1.Items.Add("rest room");
            comboBox1.Items.Add("other");
        }
    }
}
