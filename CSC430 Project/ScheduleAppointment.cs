using System;
using System.Windows.Forms;
using Appointments_API;
using User_API;
using Patient_API;

namespace CSC430_Project
{
    public partial class ScheduleAppointment : Form
    {
        public ScheduleAppointment()
        {
            InitializeComponent();
        }
        public int convertToNumericMonth(string month)
        { //put inside of Appointment, not as local function
            switch (month)
            {
                case "January":
                    return 1;
                case "February":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;
                default:
                    return 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(timeListBox.Text) == true)
            {
                MessageBox.Show("Please select a time from above.");
            }
            else
            {
                Appointment.setTime(timeListBox.Text.Split(' ')[0]);
                Appointment.setAmOrPm(timeListBox.Text.Split(' ')[1]);
                if(Appointment.isAvailable() == true)
                {
                    Appointment.scheduleAppointment(Patients.sqlFindSSN(User.getUsername()));
                    MessageBox.Show("Your appointment has been scheduled for:" +
                        Environment.NewLine + this.convertToNumericMonth(Appointment.getMonth()).ToString() +
                '/' + Appointment.getDay().ToString() + '/' +
                Appointment.getYear().ToString());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is no appointment available at that time.");
                }
            }
        }

        private void ScheduleAppointment_Load(object sender, EventArgs e)
        {
            appDateLabel.Text = this.convertToNumericMonth(Appointment.getMonth()).ToString() + 
                '/' + Appointment.getDay().ToString() + '/' + 
                Appointment.getYear().ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
