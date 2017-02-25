using System;
using MySql.Data.MySqlClient;

namespace User_API
{
    public static class User
    {
        private static string username;
        public static string getUsername()
        {
            return username;
        }
        public static void setUsername(string inName)
        {
            username = inName;
        }
        public static int findSSN(string username)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            var query = "SELECT SSN FROM user WHERE (username = @username)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return temp;
        }

        public static string findPassword(string username)
        { //We need this so that the password doesn't just sit inside of memory
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            var query = "SELECT password FROM user WHERE (username = @username)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            string temp = cmd.ExecuteScalar().ToString();
            con.Close();
            return temp;
        }

        public static int doesUserExist(string username)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            var query = "SELECT COUNT(*) FROM user WHERE (username = @username)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return temp;
        }

        public static int doesSsnExist(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT COUNT(*) FROM user WHERE (SSN = @SSN)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return temp;
        }
        public static bool Authenticate(string u, string p)
        {
            string command = "Select COUNT(username) from user where username = @user and password = @password;";
            MySqlConnection myConn = new MySqlConnection(SqlConnect.connection);
            MySqlCommand cmd = new MySqlCommand(command, myConn);
            cmd.Parameters.AddWithValue("@user", u);
            cmd.Parameters.AddWithValue("@password", p);
            return SqlConnect.CheckIfExists(cmd, myConn);
        }

        public static bool checkUsernameAndSSN(string username, int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT COUNT(*) FROM user WHERE username = @username AND SSN = @SSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            if(temp == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void addUser(string username, string password, int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            //populate database
            var query = "INSERT INTO user(username, password, SSN, isReceptionist) VALUES(@username, @password, @SSN, @isReceptionist);";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.Parameters.AddWithValue("@isReceptionist", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void removeUser(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "DELETE FROM user WHERE SSN = @SSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void updateUser(string username, int SSN, string newPassword, int tempSSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "UPDATE user SET username = @username, password = @pass, SSN = @SSN WHERE SSN = @tempSSN";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tempSSN", tempSSN);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.Parameters.AddWithValue("@pass", newPassword);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }

    public static class SqlConnect
    {
        public static string connection = "server=localhost;port=3306;username=root;password=8milerun;database=csc430project"; //Connect to database on local machine

        public static bool CheckIfExists(MySqlCommand command, MySqlConnection myConn)
        {
            myConn.Open();
            command.Prepare();
            bool temp = (Convert.ToInt32(command.ExecuteScalar()) > 0);
            myConn.Close();
            return temp;
        }
    }
}
