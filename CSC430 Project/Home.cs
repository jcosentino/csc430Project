using System;
using System.Windows.Forms;
using User_API;
using Appointments_API;
using Patient_API;

namespace CSC430_Project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortTimeString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (scheduleButton.Checked)
            {
                Appointment.setMonth(Appointment.monthToString(monthCalendar1.SelectionStart.Month));
                Appointment.setDay(monthCalendar1.SelectionStart.Day);
                Appointment.setYear(monthCalendar1.SelectionStart.Year);
                Appointment.formatDate();

                if(Appointment.getYear() < Int32.Parse(DateTime.Now.ToShortDateString().Split('/')[2]))
                {
                    MessageBox.Show("Cannot make an appointment before today's date.");
                }
                else if (Appointment.getYear() == Int32.Parse(DateTime.Now.ToShortDateString().Split('/')[2]))
                {
                    if (Appointment.totalDays(Appointment.getMonth(), Appointment.getDay()) <
                    Appointment.totalDays(Appointment.monthToString(Int32.Parse(DateTime.Now.ToShortDateString().Split('/')[0])),
                     Int32.Parse(DateTime.Now.ToShortDateString().Split('/')[1])))
                    {
                        MessageBox.Show("Cannot make an appointment before today's date.");
                    }
                    else
                    {
                        ScheduleAppointment s = new ScheduleAppointment();
                        s.Show();
                    }
                }
                else
                {
                    ScheduleAppointment s = new ScheduleAppointment();
                    s.Show();
                }
            }
            else if(rescheButton.Checked)
            {
                if (comboBox1.Text == "Upcoming appointments" || comboBox1.Text == "No Upcoming appointments")
                {
                    MessageBox.Show("You must select an upcoming appointment.");
                }
                else
                {
                    if (monthCalendar1.SelectionStart.Year < Int32.Parse(DateTime.Now.ToShortDateString().Split('/')[2]))
                    {
                        MessageBox.Show("Cannot make an appointment before today's date.");
                    }
                    else if (monthCalendar1.SelectionStart.Year == Int32.Parse(DateTime.Now.ToShortDateString().Split('/')[2]))
                    {
                        if (Appointment.totalDays(Appointment.monthToString(monthCalendar1.SelectionStart.Month), monthCalendar1.SelectionStart.Day) <
                        Appointment.totalDays(Appointment.monthToString(Int32.Parse(DateTime.Now.ToShortDateString().Split('/')[0])),
                         Int32.Parse(DateTime.Now.ToShortDateString().Split('/')[1])))
                        {
                            MessageBox.Show("Cannot make an appointment before today's date.");
                        }
                        else
                        {
                            Appointment.setMonth(comboBox1.Text.Split(' ')[0]);
                            Appointment.setDay(Int32.Parse(comboBox1.Text.Split(' ')[1]));
                            Appointment.setYear(Int32.Parse(comboBox1.Text.Split(' ')[2]));
                            Appointment.setTime(comboBox1.Text.Split(' ')[3]);
                            Appointment.setAmOrPm(comboBox1.Text.Split(' ')[4]);

                            RescheduleAppointment r =
                                new RescheduleAppointment(Appointment.monthToString(monthCalendar1.SelectionStart.Month), monthCalendar1.SelectionStart.Day,
                                monthCalendar1.SelectionStart.Year);
                            r.Show();
                        }
                    }
                    else
                    {
                        Appointment.setMonth(comboBox1.Text.Split(' ')[0]);
                        Appointment.setDay(Int32.Parse(comboBox1.Text.Split(' ')[1]));
                        Appointment.setYear(Int32.Parse(comboBox1.Text.Split(' ')[2]));
                        Appointment.setTime(comboBox1.Text.Split(' ')[3]);
                        Appointment.setAmOrPm(comboBox1.Text.Split(' ')[4]);

                        RescheduleAppointment r =
                            new RescheduleAppointment(Appointment.monthToString(monthCalendar1.SelectionStart.Month), monthCalendar1.SelectionStart.Day,
                            monthCalendar1.SelectionStart.Year);
                        r.Show();
                    }
                }
            }
            else if (cancelButton.Checked)
            {
                if(comboBox1.Text == "Upcoming appointments" || comboBox1.Text == "No Upcoming appointments")
                {
                    MessageBox.Show("You must select an appoint to cancel.");
                }
                else
                {

                    Appointment.setMonth(comboBox1.Text.Split(' ')[0]);
                    Appointment.setDay(Int32.Parse(comboBox1.Text.Split(' ')[1]));
                    Appointment.setYear(Int32.Parse(comboBox1.Text.Split(' ')[2]));
                    Appointment.setTime(comboBox1.Text.Split(' ')[3]);
                    Appointment.setAmOrPm(comboBox1.Text.Split(' ')[4]);

                    var result = MessageBox.Show("Are you sure you want to cancel your appointment?", "Cancel Appointment", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Appointment.cancelAppointment(Patients.sqlFindSSN(User.getUsername()));
                        MessageBox.Show("Your appointment has been cancelled.");
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            else if (modifyButton.Checked)
            {
                ModifyPersonalInfo m = new ModifyPersonalInfo();
                m.Show();
            }
            else if (deletePersButton.Checked)
            {
                DeletePersonalInfo d = new DeletePersonalInfo();
                d.Show();
            }
            else
            {
                MessageBox.Show("Please select an option from above.");
            }
        }

        private void Home_Activated(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (Appointment.areThereAppointments(Patients.sqlFindSSN(User.getUsername())) == true)
            {
                comboBox1.Text = "Upcoming appointments";
                for (int i = 0; i < Appointment.listAppointments(Patients.sqlFindSSN(User.getUsername())).Count; i++)
                {
                    comboBox1.Items.Add(Appointment.listAppointments(Patients.sqlFindSSN(User.getUsername()))[i] + ' ' +
                        Appointment.listAppointments(Patients.sqlFindSSN(User.getUsername()))[i + 1] + ' '
                        + Appointment.listAppointments(Patients.sqlFindSSN(User.getUsername()))[i + 2] + ' '
                         + Appointment.listAppointments(Patients.sqlFindSSN(User.getUsername()))[i + 3] + ' '
                         + Appointment.listAppointments(Patients.sqlFindSSN(User.getUsername()))[4]);
                    i += 4;
                }
            }
            else
            {
                comboBox1.Text = "No Upcoming appointments";
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if(Appointment.isBookedForDay(Appointment.monthToString(monthCalendar1.SelectionStart.Month), 
                monthCalendar1.SelectionStart.Day, monthCalendar1.SelectionStart.Year) == true)
            {
                MessageBox.Show("The doctor is booked that day.");
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (Appointment.isBookedForDay(Appointment.monthToString(monthCalendar1.SelectionStart.Month),
                monthCalendar1.SelectionStart.Day, monthCalendar1.SelectionStart.Year) == true)
            {
                MessageBox.Show("The doctor is booked that day.");
            }
        }
    }
}
