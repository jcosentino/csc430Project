using System;
using System.Windows.Forms;
using Appointments_API;
using Patient_API;
using User_API;

namespace CSC430_Project
{
    public partial class RescheduleAppointment : Form
    {
        public string newMonth;
        public int newDay;
        public int newYear;
        public string time;
        public string amOrPmn;
        public RescheduleAppointment()
        {
            InitializeComponent();
        }

        public RescheduleAppointment(string newMonth, int newDay, int newYear)
        {
            this.newMonth = newMonth;
            this.newDay = newDay;
            this.newYear = newYear;

            InitializeComponent();
        }
        public int convertToNumericMonth(string month)
        {
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
        private void RescheduleAppointment_Load(object sender, EventArgs e)
        {
            appDateLabel.Text = this.convertToNumericMonth(newMonth).ToString() +
                '/' + newDay.ToString() + '/' +
                newYear.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(timeListBox.Text) == true){
                MessageBox.Show("Please select a time from above.");
            }
            else
            {
                if (Appointment.isAvailableForReschedule(newMonth, newDay, newYear,
                    timeListBox.Text.Split(' ')[0], timeListBox.Text.Split(' ')[1]) == true)
                {
                    Appointment.cancelAppointment(Patients.sqlFindSSN(User.getUsername()));

                    Appointment.setMonth(newMonth);
                    Appointment.setDay(newDay);
                    Appointment.setYear(newYear);
                    Appointment.setTime(timeListBox.Text.Split(' ')[0]);
                    Appointment.setAmOrPm(timeListBox.Text.Split(' ')[1]);
                    Appointment.formatDate();

                    Appointment.scheduleAppointment(Patients.sqlFindSSN(User.getUsername()));
                    MessageBox.Show("Your appointment was rescheduled for:" +
                        Environment.NewLine + Appointment.getFormattedDate());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is no appointment available at that time.");
                }
            }
        }
    }
}
