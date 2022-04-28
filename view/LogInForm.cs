using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.utils;
using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.view.ManagerView;

namespace HealthCareInfromationSystem.view
{
	public partial class LogInForm : Form
	{
		public LogInForm()
		{
			InitializeComponent();
		}

		private void LogInButtonClik(object sender, EventArgs e)
		{
			string inputUsername = usernameTextBox.Text;
			string inputPassword = passwordTextBox.Text;
			if (inputUsername.Equals("") || inputPassword.Equals(""))
			{
				errorLabel.Text = "You must fill in the form";
				return;
			}
			Person loggedUser = PersonController.LoadOnePerson(Constants.connectionString, "select * from users where username=\"" + inputUsername + "\" and password=\"" + inputPassword + "\"");

			//checking if we found an user
			if (loggedUser is null)
			{
				errorLabel.Text = "Username or password incorrect";
				return;
			}
			//add user to LoggedInUser class
			LoggedInUser.loggedIn = loggedUser;

			//user found, opening windows based on user type
			if (loggedUser.Role == Person.Roles.secretary) { errorLabel.Text = "Welcome secretary"; }

			else if (loggedUser.Role == Person.Roles.doctor)
			{
				errorLabel.Text = "Welcome doctor";
				//DoctorMainForm doctorMainForm = new DoctorMainForm();
				//doctorMainForm.Show();

			}
			else if (loggedUser.Role == Person.Roles.patient) { errorLabel.Text = "Welcome patient"; }
			else 
			{
				ManagerMainForm managerMainForm = new ManagerMainForm();
				managerMainForm.Show();
			} //manager


		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void LogInForm_Load(object sender, EventArgs e)
		{

		}
	}
}
