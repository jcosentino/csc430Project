using System;
using System.Windows.Forms;
using Patient_API;
using User_API;
using Appointments_API;

namespace CSC430_Project
{
    public partial class DeletePersonalInfo : Form
    {
        public DeletePersonalInfo()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DeletePersonalInfo_Load(object sender, EventArgs e)
        {
            usernameBox.Text = User.getUsername();
            passwordBox.Text = User.findPassword(User.getUsername());
            firstnameBox.Text = Patients.sqlFindFirstName(Patients.sqlFindSSN(User.getUsername()));
            lastnameBox.Text = Patients.sqlFindLastName(Patients.sqlFindSSN(User.getUsername()));
            ssnBox.Text = Patients.sqlFindSSN(User.getUsername()).ToString();
            pnumBox.Text = Patients.sqlFindPhoneNumber(Patients.sqlFindSSN(User.getUsername()));
            monthComboBox.Text = Patients.sqlFindBirthDate(Patients.sqlFindSSN(User.getUsername())).Split('/')[0];
            dayComboBox.Text = Patients.sqlFindBirthDate(Patients.sqlFindSSN(User.getUsername())).Split('/')[1];
            yearComboBox.Text = Patients.sqlFindBirthDate(Patients.sqlFindSSN(User.getUsername())).Split('/')[2];
            companyBox.Text = Insurance.sqlFindInsuranceCompany(Patients.sqlFindMemberID(Patients.sqlFindSSN(User.getUsername())));
            policyBox.Text = Insurance.sqlFindInsurancePolicy(Patients.sqlFindMemberID(Patients.sqlFindSSN(User.getUsername())));
            gnumberBox.Text = Insurance.sqlFindGroupNumber(Patients.sqlFindMemberID(Patients.sqlFindSSN(User.getUsername()))).ToString();
            memberidBox.Text = Patients.sqlFindMemberID(Patients.sqlFindSSN(User.getUsername())).ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete your account?", "Delete user", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                User.removeUser(User.findSSN(User.getUsername()));
                Insurance.deleteInsurance(Int32.Parse(memberidBox.Text));
                Patients.deletePatient(Int32.Parse(ssnBox.Text));
                MessageBox.Show("User has been deleted.");
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                this.Close();
            }
        }
    }
}
