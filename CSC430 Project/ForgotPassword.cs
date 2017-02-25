using System;
using System.Drawing;
using System.Windows.Forms;
using User_API;

namespace CSC430_Project
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(usernameBox.Text) == true || string.IsNullOrWhiteSpace(ssnBox.Text) == true
                || string.IsNullOrWhiteSpace(passwordBox.Text) == true)
            {
                if (string.IsNullOrWhiteSpace(usernameBox.Text) == true)
                {
                    usernameBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(ssnBox.Text) == true)
                {
                    ssnBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(passwordBox.Text) == true)
                {
                    passwordBox.BackColor = System.Drawing.Color.PeachPuff;
                }

                MessageBox.Show("One or more fields is empty!");
            }
            else
            {
                int temp = 0;
                if (Int32.TryParse(ssnBox.Text, out temp) == true)
                {
                    if (User.checkUsernameAndSSN(usernameBox.Text, Int32.Parse(ssnBox.Text)) == true)
                    {
                        User.updateUser(usernameBox.Text, Int32.Parse(ssnBox.Text), passwordBox.Text, Int32.Parse(ssnBox.Text));
                        MessageBox.Show("User password has changed!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username / SSN do not match");
                    }
                }
                else
                {
                    ssnBox.BackColor = Color.Red;
                    MessageBox.Show("Only valid numbers for SSN!");
                }
            }
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            usernameBox.BackColor = System.Drawing.Color.Empty;
        }

        private void ssnBox_TextChanged(object sender, EventArgs e)
        {
            ssnBox.BackColor = System.Drawing.Color.Empty;
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            usernameBox.BackColor = System.Drawing.Color.Empty;
        }
    }
}
