using System;
using System.Windows.Forms;
using User_API;

namespace CSC430_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword f = new ForgotPassword();
            f.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            usernameBox.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(usernameBox.Text) == true || string.IsNullOrWhiteSpace(passwordBox.Text) == true)
            {
                if(string.IsNullOrWhiteSpace(usernameBox.Text) == true)
                {
                    usernameBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                if (string.IsNullOrWhiteSpace(passwordBox.Text) == true)
                {
                    passwordBox.BackColor = System.Drawing.Color.PeachPuff;
                }
                MessageBox.Show("One or more fields is empty!");
            }
            else
            {
                if (User.Authenticate(usernameBox.Text, passwordBox.Text))
                {
                    User.setUsername(usernameBox.Text);
                    Home obj = new Home();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("User does not exist/password is incorrect.");
                    usernameBox.BackColor = System.Drawing.Color.PeachPuff;
                    passwordBox.BackColor = System.Drawing.Color.PeachPuff;
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewUser newuser = new NewUser();
            newuser.Show();
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            usernameBox.BackColor = System.Drawing.Color.Empty;
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            passwordBox.BackColor = System.Drawing.Color.Empty;
        }

        private void passwordBox_Enter(object sender, EventArgs e)
        {
            passwordBox.Text = null;
        }

        private void usernameBox_Enter(object sender, EventArgs e)
        {
            usernameBox.Text = null;
            passwordBox.Text = null;
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
                //press Enter to utilize the button
            }
        }

        private void usernameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
                //press Enter to utilize the button
            }
        }
    }
}
