using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Appointments_API
{
    public static class Appointment
    {
        private static string month;
        private static int day;
        private static int year;
        private static string time;
        private static string amOrPm;
        private static string formattedDate;

        public static string getMonth()
        {
            return month;
        }

        public static void setMonth(string inMonth)
        {
            month = inMonth;
        }

        public static int getDay()
        {
            return day;
        }

        public static void setDay(int inDay)
        {
            day = inDay;
        }

        public static int getYear()
        {
            return year;
        }

        public static void setYear(int inYear)
        {
            year = inYear;
        }

        public static string getFormattedDate()
        {
            return formattedDate;
        }
        public static void formatDate()
        {
            formattedDate = Appointment.getMonth() + '/' + Appointment.getDay() + '/'
                + Appointment.getYear();
        }

        public static string getTime()
        {
            return time;
        }

        public static void setTime(string inTime)
        {
            time = inTime;
        }

        public static string getAmOrPm()
        {
            return amOrPm;
        }

        public static void setAmOrPm(string inM)
        {
            amOrPm = inM;
        }

        public static string monthToString(int numericMonth)
        {
            switch (numericMonth)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "NOT A MONTH";
            }
        }

        public static bool isAvailable()
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            var query = "SELECT COUNT(*) FROM appointment WHERE (month = @month) AND (day = @day) AND (year = @year) AND (time = @time) AND (amOrPm = @amOrPm)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@month", Appointment.getMonth());
            cmd.Parameters.AddWithValue("@day", Appointment.getDay());
            cmd.Parameters.AddWithValue("@year", Appointment.getYear());
            cmd.Parameters.AddWithValue("@time", Appointment.getTime());
            cmd.Parameters.AddWithValue("@amOrPm", Appointment.getAmOrPm());
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());

            if(temp == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool isAvailableForReschedule(string month, int day, int year, string time, string amOrPm)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            var query = "SELECT COUNT(*) FROM appointment WHERE (month = @month) AND (day = @day) AND (year = @year) AND (time = @time) AND (amOrPm = @amOrPm)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@day", day);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@amOrPm", amOrPm);
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());

            if (temp == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool isBookedForDay(string month, int day, int year)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            var query = "SELECT COUNT(*) FROM appointment WHERE (month = @month) AND (day = @day) AND (year = @year)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@day", day);
            cmd.Parameters.AddWithValue("@year", year);
            
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());

            if (temp == 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int totalDays(string month, int day)
        {
            switch (month)
            {
                case "January":
                    return day;
                case "February":
                    return 31 + day;
                case "March":
                    return 59 + day;
                case "April":
                    return 90 + day;
                case "May":
                    return 120 + day;
                case "June":
                    return 151 + day;
                case "July":
                    return 181 + day;
                case "August":
                    return 212 + day;
                case "September":
                    return 243 + day;
                case "October":
                    return 273 + day;
                case "November":
                    return 304 + day;
                case "December":
                    return 334 + day;
                default:
                    return 0;
            }
        }

        public static void scheduleAppointment(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "INSERT INTO appointment (month, day, year, time, amOrPm, SSN) VALUES (@month, @day, @year, @time, @amOrPm, @SSN);";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@month", Appointment.getMonth());
            cmd.Parameters.AddWithValue("@day", Appointment.getDay());
            cmd.Parameters.AddWithValue("@year", Appointment.getYear());
            cmd.Parameters.AddWithValue("@time", Appointment.getTime());
            cmd.Parameters.AddWithValue("@amOrPm", Appointment.getAmOrPm());
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void cancelAppointment(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "DELETE FROM appointment WHERE month = @month AND day = @day AND year = @year AND time = @time AND amOrPm = @amOrPm AND SSN = @SSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.Parameters.AddWithValue("@month", Appointment.getMonth());
            cmd.Parameters.AddWithValue("@day", Appointment.getDay());
            cmd.Parameters.AddWithValue("@year", Appointment.getYear());
            cmd.Parameters.AddWithValue("@time", Appointment.getTime());
            cmd.Parameters.AddWithValue("@amOrPm", Appointment.getAmOrPm());

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public static void eraseAllApps(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "DELETE FROM appointment WHERE SSN = @SSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.ExecuteNonQuery();

            con.Close();
        } //This has to be executed while MySql has safe mode disabled

        public static List<string> listAppointments(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            List<string> list = new List<string>();

            var query = "SELECT month, day, year, time, amOrPm FROM appointment WHERE SSN = @SSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
                list.Add(reader.GetString(1));
                list.Add(reader.GetString(2));
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
            }
            con.Close();
            return list;
        }
        public static bool areThereAppointments(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            var query = "SELECT COUNT(*) FROM appointment WHERE SSN = @SSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());

            if(temp == 0)
            {
                return false;
            }
            return true;
        }

        public static bool isProperTime()
        {
            if(Appointment.getAmOrPm() == "AM")
            {
                if(Int32.Parse(Appointment.getTime().Replace(":", "")) >= 800 &&
                    Int32.Parse(Appointment.getTime().Replace(":", "")) <= 1130)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (Int32.Parse(Appointment.getTime().Replace(":", "")) >= 100 &&
                    Int32.Parse(Appointment.getTime().Replace(":", "")) <= 430)
                {
                    return true;
                }
                else if(Int32.Parse(Appointment.getTime().Replace(":", "")) == 1230)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
