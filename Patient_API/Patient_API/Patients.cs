using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Patient_API
{
    public static class Insurance
    {
        private static int memberID;
        private static string insuranceCompany;
        private static string insurancePolicy;
        private static int groupNumber;

        public static int getMemberID()
        {
            return memberID;
        }

        public static void setMemberID(int inID)
        {
            memberID = inID;
        }

        public static string getInsuranceCompany()
        {
            return insuranceCompany;
        }

        public static void setInsuranceCompany(string name)
        {
            insuranceCompany = name;
        }

        public static string getInsurancePolicy()
        {
            return insurancePolicy;
        }

        public static void setInsurancePolicy(string policy)
        {
            insurancePolicy = policy;
        }

        public static int getGroupNumber()
        {
            return groupNumber;
        }

        public static void setGroupNumber(int num)
        {
            groupNumber = num;
        }

        public static int doesMemberIdExist(int memberID)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT COUNT(*) FROM insurance WHERE (memberID = @memberID)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@memberID", memberID);
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return temp;
        }
        public static string sqlFindInsuranceCompany(int memberID)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT insuranceCompany FROM insurance WHERE memberID = @memberID; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@memberID", memberID);
            string company = cmd.ExecuteScalar().ToString(); //NEEDTHIS
            con.Close();
            return company;
        }

        public static string sqlFindInsurancePolicy(int memberID)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT insurancePolicy FROM insurance WHERE memberID = @memberID; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@memberID", memberID);
            string policy = cmd.ExecuteScalar().ToString(); //NEEDTHIS
            con.Close();
            return policy;
        }

        public static int sqlFindGroupNumber(int memberID)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT groupNumber FROM insurance WHERE memberID = @memberID; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@memberID", memberID);
            int gNum = Int32.Parse(cmd.ExecuteScalar().ToString()); //NEEDTHIS
            con.Close();
            return gNum;
        }
        public static void createInsurance(int memberID)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "INSERT INTO insurance(memberID, insuranceCompany, insurancePolicy, groupNumber) VALUES(@memberID, @insuranceCo, @insurancePol, @groupNum);";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@memberID", memberID);
            cmd.Parameters.AddWithValue("@insuranceCo", Insurance.getInsuranceCompany());
            cmd.Parameters.AddWithValue("@insurancePol", Insurance.getInsurancePolicy());
            cmd.Parameters.AddWithValue("@groupNum", Insurance.getGroupNumber());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void updateInsurance(int tempMemberID)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "UPDATE insurance SET memberID = @memberID, insuranceCompany = @insuranceCo, insurancePolicy = @insurancePol, groupNumber = @groupNum WHERE memberID = @tempMemberID;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tempMemberID", tempMemberID);
            cmd.Parameters.AddWithValue("@memberID", Insurance.getMemberID());
            cmd.Parameters.AddWithValue("@insuranceCo", Insurance.getInsuranceCompany());
            cmd.Parameters.AddWithValue("@insurancePol", Insurance.getInsurancePolicy());
            cmd.Parameters.AddWithValue("@groupNum", Insurance.getGroupNumber());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void deleteInsurance(int memberID)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "DELETE FROM insurance WHERE memberID = @memberID;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@memberID", memberID);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
    public static class Patients
    {
        private static int SSN;
        private static string firstName;
        private static string lastName;
        private static string phoneNumber;
        private static string birthDate;
        private static string username;
        private static int memberID;

        public static int getSSN()
        {
            return SSN;
        }

        public static void setSSN(int inSSN)
        {
            SSN = inSSN;
        }

        public static string getFirstName()
        {
            return firstName;
        }

        public static void setFirstName(string inName)
        {
            firstName = inName;
        }

        public static string getLastName()
        {
            return lastName;
        }

        public static void setLastName(string inName)
        {
            lastName = inName;
        }

        public static string getPhoneNumber()
        {
            return phoneNumber;
        }

        public static void setPhoneNumber(string inNum)
        {
            phoneNumber = inNum;
        }

        public static string getBirthDate()
        {
            return birthDate;
        }

        public static void setBirthDate(string inDate)
        {
            birthDate = inDate;
        }

        public static string getUsername()
        {
            return username;
        }

        public static void setUsername(string inName)
        {
            username = inName;
        }

        public static int getMemberID()
        {
            return memberID;
        }

        public static void setMemberID(int inID)
        {
            memberID = inID;
        }

        public static int doesMemberIdExist(int memberID)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT COUNT(*) FROM patients WHERE (memberID = @memberID)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@memberID", memberID);
            int temp = Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return temp;
        }
        public static int sqlFindSSN(string username)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT SSN FROM user WHERE username = @username;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            int SSN = Int32.Parse(cmd.ExecuteScalar().ToString()); //NEEDTHIS
            con.Close();
            return SSN;
        }

        public static string sqlFindFirstName(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT firstName FROM patients WHERE SSN = @SSN; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            string firstName = cmd.ExecuteScalar().ToString(); //NEEDTHIS
            con.Close();
            return firstName;
        }

        public static string sqlFindLastName(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT lastName FROM patients WHERE SSN = @SSN; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            string lastName = cmd.ExecuteScalar().ToString(); //NEEDTHIS
            con.Close();
            return lastName;
        }

        public static string sqlFindPhoneNumber(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT phoneNumber FROM patients WHERE SSN = @SSN; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            string pNumber = cmd.ExecuteScalar().ToString(); //NEEDTHIS
            con.Close();
            return pNumber;
        }

        public static string sqlFindBirthDate(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT birthDate FROM patients WHERE SSN = @SSN; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            string bDate = cmd.ExecuteScalar().ToString(); //NEEDTHIS
            con.Close();
            return bDate;
        }

        public static int sqlFindMemberID(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "SELECT memberID FROM patients WHERE SSN = @SSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            int memberID = Int32.Parse(cmd.ExecuteScalar().ToString()); //NEEDTHIS
            con.Close();
            return memberID;
        }
        public static bool doesUserExist()
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            var query = "SELECT SSN FROM patients WHERE (SSN = @SSN)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@SSN", SSN);

            if(cmd.ExecuteScalar() == null)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }
        public static void newUser()
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            //populate database
            var addQ = "INSERT INTO patients(SSN, firstName, lastName, phoneNumber, birthDate, memberID) VALUES(@SSN, @firstN, @lastN, @pNum, @bDate, @mID);";
            MySqlCommand addC = new MySqlCommand(addQ, con);
            addC.Parameters.AddWithValue("@SSN", Patients.getSSN());
            addC.Parameters.AddWithValue("@firstN", Patients.getFirstName());
            addC.Parameters.AddWithValue("@lastN", Patients.getLastName());
            addC.Parameters.AddWithValue("@pNum", Patients.getPhoneNumber());
            addC.Parameters.AddWithValue("@bDate", Patients.getBirthDate());
            addC.Parameters.AddWithValue("@mID", Patients.getMemberID());
            addC.ExecuteNonQuery(); //NEEDTHIS
            con.Close();
        }

        public static void updatePatient(int tempSSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            //populate database

            var query = "UPDATE patients SET SSN = @SSN, firstName = @firstN, lastName = @lastN, phoneNumber = @pNum, birthDate = @bDate, memberID = @mID WHERE SSN = @tempSSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tempSSN", tempSSN); //old SSN
            cmd.Parameters.AddWithValue("@SSN", Patients.getSSN());
            cmd.Parameters.AddWithValue("@firstN", Patients.getFirstName());
            cmd.Parameters.AddWithValue("@lastN", Patients.getLastName());
            cmd.Parameters.AddWithValue("@pNum", Patients.getPhoneNumber());
            cmd.Parameters.AddWithValue("@bDate", Patients.getBirthDate());
            cmd.Parameters.AddWithValue("@mID", Patients.getMemberID());
            cmd.ExecuteNonQuery(); //NEEDTHIS
            con.Close();
        }

        public static void deletePatient(int SSN)
        {
            string connection = "server=localhost; User Id=root; password=8milerun; database=csc430project;";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            var query = "DELETE FROM patients WHERE SSN = @SSN;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
