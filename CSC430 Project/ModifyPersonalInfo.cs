using System;
using System.Windows.Forms;
using Patient_API;
using User_API;

namespace CSC430_Project
{
    public partial class ModifyPersonalInfo : Form
    {
        public int tempSSN;
        public int tempMemberID;
        public string tempUsername;
        public ModifyPersonalInfo()
        {
            InitializeComponent();
        }

        private void ModifyPersonalInfo_Load(object sender, EventArgs e)
        {
            dayComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            usernameBox.Text = User.getUsername();
            tempUsername = usernameBox.Text;
            passwordBox.Text = User.findPassword(User.getUsername());
            firstnameBox.Text = Patients.sqlFindFirstName(Patients.sqlFindSSN(User.getUsername()));
            lastnameBox.Text = Patients.sqlFindLastName(Patients.sqlFindSSN(User.getUsername()));
            ssnBox.Text = Patients.sqlFindSSN(User.getUsername()).ToString();
            tempSSN = Int32.Parse(ssnBox.Text); //get original SSN
            pnumBox.Text = Patients.sqlFindPhoneNumber(Patients.sqlFindSSN(User.getUsername()));
            monthComboBox.Text = Patients.sqlFindBirthDate(Patients.sqlFindSSN(User.getUsername())).Split('/')[0];
            dayComboBox.Text = Patients.sqlFindBirthDate(Patients.sqlFindSSN(User.getUsername())).Split('/')[1];
            yearComboBox.Text = Patients.sqlFindBirthDate(Patients.sqlFindSSN(User.getUsername())).Split('/')[2];
            companyBox.Text = Insurance.sqlFindInsuranceCompany(Patients.sqlFindMemberID(Patients.sqlFindSSN(User.getUsername())));
            policyBox.Text = Insurance.sqlFindInsurancePolicy(Patients.sqlFindMemberID(Patients.sqlFindSSN(User.getUsername())));
            gnumberBox.Text = Insurance.sqlFindGroupNumber(Patients.sqlFindMemberID(Patients.sqlFindSSN(User.getUsername()))).ToString();
            memberidBox.Text = Patients.sqlFindMemberID(Patients.sqlFindSSN(User.getUsername())).ToString();
            tempMemberID = Int32.Parse(memberidBox.Text); //keep original memberID
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
                    int test = 0;
                    if (Int32.TryParse(ssnBox.Text, out test) == false)
                    {
                        ssnBox.BackColor = System.Drawing.Color.PeachPuff;
                        MessageBox.Show("Social Security must be a number.");
                    }
                    else
                    {
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
                                        Patients.setFirstName(firstnameBox.Text);
                                        Patients.setLastName(lastnameBox.Text);
                                        Patients.setSSN(Int32.Parse(ssnBox.Text));
                                        Patients.setPhoneNumber(pnumBox.Text);
                                        Patients.setBirthDate(monthComboBox.Text + '/' + dayComboBox.Text + '/' + yearComboBox.Text);
                                        Insurance.setInsuranceCompany(companyBox.Text);
                                        Insurance.setInsurancePolicy(policyBox.Text);
                                        Insurance.setGroupNumber(Int32.Parse(gnumberBox.Text));
                                        Insurance.setMemberID(Int32.Parse(memberidBox.Text));
                                        Patients.setMemberID(Int32.Parse(memberidBox.Text));

                                        User.updateUser(usernameBox.Text, Patients.getSSN(), passwordBox.Text, tempSSN);
                                        Insurance.updateInsurance(tempMemberID);
                                        Patients.updatePatient(tempSSN);
                                        MessageBox.Show("Your information has been updated");
                            }
                        }
                    }
            }
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

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            passwordBox.BackColor = System.Drawing.Color.Empty;
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

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
