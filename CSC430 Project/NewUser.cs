using System;
using System.Windows.Forms;
using Patient_API;
using User_API;

namespace CSC430_Project
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(usernameBox.Text) == true || string.IsNullOrWhiteSpace(passwordBox.Text) == true
                || string.IsNullOrWhiteSpace(firstnameBox.Text) == true || string.IsNullOrWhiteSpace(lastnameBox.Text) == true
                || string.IsNullOrWhiteSpace(ssnBox.Text) == true || string.IsNullOrWhiteSpace(pnumBox.Text) == true
                || string.IsNullOrWhiteSpace(pnumBox.Text) == true || monthComboBox.Text == "Month" || dayComboBox.Text == "Day"
                    || yearComboBox.Text == "Year" || string.IsNullOrWhiteSpace(companyBox.Text) == true || string.IsNullOrWhiteSpace(policyBox.Text) == true
                    || string.IsNullOrWhiteSpace(gnumberBox.Text) == true || string.IsNullOrWhiteSpace(memberidBox.Text) == true)
            {
                if (string.IsNullOrWhiteSpace(usernameBox.Text) == true)
                {
                    usernameBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(passwordBox.Text) == true)
                {
                    passwordBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(firstnameBox.Text) == true)
                {
                    firstnameBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(lastnameBox.Text) == true)
                {
                    lastnameBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(ssnBox.Text) == true)
                {
                    ssnBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(pnumBox.Text) == true)
                {
                    pnumBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(companyBox.Text) == true)
                {
                    companyBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(policyBox.Text) == true)
                {
                    policyBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(gnumberBox.Text) == true)
                {
                    gnumberBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(memberidBox.Text) == true)
                {
                    memberidBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (monthComboBox.Text == "Month")
                {
                    monthComboBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (dayComboBox.Text == "Day")
                {
                    dayComboBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (yearComboBox.Text == "Year")
                {
                    yearComboBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                MessageBox.Show("One or more fields is blank!");
            }
            else
            {
                if (User.doesUserExist(usernameBox.Text) != 0)
                {
                    usernameBox.BackColor = System.Drawing.Color.PeachPuff;
                    passwordBox.BackColor = System.Drawing.Color.PeachPuff;
                    MessageBox.Show("Invalid username and/or password");
                }
                else
                {
                    int test = 0;
                    if (Int32.TryParse(ssnBox.Text, out test) == false)
                    {
                        ssnBox.BackColor = System.Drawing.Color.PeachPuff;
                        MessageBox.Show("Social Security must be a number.");
                    }
                    else
                    {
                        if (ssnBox.Text.Length < 9)
                        {
                            MessageBox.Show("SSN must be 9 digits in length!");
                            ssnBox.BackColor = System.Drawing.Color.PeachPuff;
                        }
                        else { 

                        if (Int32.TryParse(gnumberBox.Text, out test) == false)
                        {
                            gnumberBox.BackColor = System.Drawing.Color.PeachPuff;
                            MessageBox.Show("Group Number must be a number.");
                        }
                        else
                        {
                            if (Int32.TryParse(memberidBox.Text, out test) == false)
                            {
                                memberidBox.BackColor = System.Drawing.Color.PeachPuff;
                                MessageBox.Show("Member ID must be a number.");
                            }
                            else
                            {
                                if (User.doesSsnExist(Int32.Parse(ssnBox.Text)) != 0)
                                {
                                    ssnBox.BackColor = System.Drawing.Color.PeachPuff;
                                    MessageBox.Show("Invalid SSN.");
                                }
                                else
                                {
                                    if (Insurance.doesMemberIdExist(Int32.Parse(memberidBox.Text)) +
                                        Patients.doesMemberIdExist(Int32.Parse(memberidBox.Text)) != 0)
                                    {
                                        memberidBox.BackColor = System.Drawing.Color.PeachPuff;
                                        MessageBox.Show("Invalid member ID.");
                                    }
                                    else
                                    {
                                        User.addUser(usernameBox.Text, passwordBox.Text, Int32.Parse(ssnBox.Text));

                                        Insurance.setInsuranceCompany(companyBox.Text);
                                        Insurance.setInsurancePolicy(policyBox.Text);
                                        Insurance.setGroupNumber(Int32.Parse(gnumberBox.Text));
                                        Insurance.setMemberID(Int32.Parse(memberidBox.Text));
                                        Insurance.createInsurance(Int32.Parse(memberidBox.Text));

                                        Patients.setFirstName(firstnameBox.Text);
                                        Patients.setLastName(lastnameBox.Text);
                                        Patients.setSSN(Int32.Parse(ssnBox.Text));
                                        Patients.setPhoneNumber(pnumBox.Text);
                                        Patients.setBirthDate(monthComboBox.Text + '/' + dayComboBox.Text + '/' + yearComboBox.Text);
                                        Patients.setMemberID(Int32.Parse(memberidBox.Text));
                                        Patients.newUser();

                                        MessageBox.Show("User has been added.");
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                  }
                }
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            passwordBox.BackColor = System.Drawing.Color.Empty; 
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void monthComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void monthComboBox_TextUpdate(object sender, EventArgs e)
        {
        }

        private void monthComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            dayComboBox.Items.Clear();
            switch (monthComboBox.Text)
            {
                case "September":
                case "April":
                case "June":
                case "November":
                    for (int i = 1; i <= 30; i++)
                    {
                        dayComboBox.Items.Add(i.ToString());
                    }
                    break;
                case "February":
                    for (int i = 1; i <= 28; i++)
                    {
                        dayComboBox.Items.Add(i);
                    }
                    break;
                default:
                    for (int i = 1; i <= 31; i++)
                    {
                        dayComboBox.Items.Add(i);
                    }
                    break;
            }
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            usernameBox.BackColor = System.Drawing.Color.Empty;
        }

        private void firstnameBox_TextChanged(object sender, EventArgs e)
        {
            firstnameBox.BackColor = System.Drawing.Color.Empty;
        }

        private void lastnameBox_TextChanged(object sender, EventArgs e)
        {
            lastnameBox.BackColor = System.Drawing.Color.Empty;
        }

        private void ssnBox_TextChanged(object sender, EventArgs e)
        {
            ssnBox.BackColor = System.Drawing.Color.Empty;
        }

        private void pnumBox_TextChanged(object sender, EventArgs e)
        {
            pnumBox.BackColor = System.Drawing.Color.Empty;
        }

        private void monthComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            monthComboBox.BackColor = System.Drawing.Color.Empty;
        }

        private void dayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dayComboBox.BackColor = System.Drawing.Color.Empty;
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearComboBox.BackColor = System.Drawing.Color.Empty;
        }

        private void companyBox_TextChanged(object sender, EventArgs e)
        {
            companyBox.BackColor = System.Drawing.Color.Empty;
        }

        private void policyBox_TextChanged(object sender, EventArgs e)
        {
            policyBox.BackColor = System.Drawing.Color.Empty;
        }

        private void gnumberBox_TextChanged(object sender, EventArgs e)
        {
            gnumberBox.BackColor = System.Drawing.Color.Empty;
        }

        private void memberidBox_TextChanged(object sender, EventArgs e)
        {
            memberidBox.BackColor = System.Drawing.Color.Empty;
        }
    }
}
