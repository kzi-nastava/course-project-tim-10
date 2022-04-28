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
    public partial class ArrangingEquipmentForm : Form
    {
        public ArrangingEquipmentForm()
        {
            InitializeComponent();
        }

        private void SetLabelsAndButtons()
        {
            label1.Text = "Current premise";
            label2.Text = "New premise";
            label3.Text = "Move date";
            textBox1.Enabled = false;
            button1.Text = "Move";
        }

        private bool CheckIfTextBoxesAreEmpty()
        {
            return String.IsNullOrWhiteSpace(textBox1.Text) ||
                    comboBox1.SelectedItem == null ||
                    String.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()) ||
                    String.IsNullOrWhiteSpace(textBox2.Text);
        }
    }
}
