using Dll.Generic;
using Dll.BL;
using Dll.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Dll.DL
{
    public class EmployeeDBstore : IEmployee
    {
        public string connectionString = Utilities.utility.getconnString();
        static EmployeeDBstore instance;

        private EmployeeDBstore(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public static EmployeeDBstore getInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new EmployeeDBstore(connectionString);
            }
            return instance;
        }
        
        public bool addEmployee(EmployeeUser user)
        {
            if (!(MuserDBStore.validateUser(user,connectionString)))
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = String.Format("INSERT INTO Users(username,password,role,name,salary,dob,email,mobile) VALUES('{0}', '{1}', '{2}' , '{3}' , '{4}' , '{5}' , '{6}' , '{7}')", user.getUserName(), user.getUserPassword(), user.getUserRole(), user.getName(), user.getSalary(), user.getDob(), user.getEmail(), user.getMobileNo());
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }

        public void delEmployee(EmployeeUser user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("DELETE FROM Users WHERE username = '{0}'", user.getUserName());
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<EmployeeUser> getEmployeeData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Users where role='Pharmacist' OR role='Technician' ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<EmployeeUser> users = new List<EmployeeUser>();
            while (reader.Read())
            {
                EmployeeUser user = new EmployeeUser(reader["dob"].ToString(), reader["salary"].ToString(), reader["email"].ToString(), reader["mobile"].ToString(), reader["role"].ToString(), reader["password"].ToString(), reader["username"].ToString(), reader["name"].ToString());
                users.Add(user);
            }
            connection.Close();
            return users;
        }

        public void updateEmployee(EmployeeUser user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format(@"UPDATE Users set password =@password, role =@role, name =@name, salary =@salary, dob =@dob, email =@email, mobile =@mobile WHERE username =@username");

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", user.getUserName());
            command.Parameters.AddWithValue("@password", user.getUserPassword());
            command.Parameters.AddWithValue("@role", user.getUserRole());
            command.Parameters.AddWithValue("@name", user.getName());
            command.Parameters.AddWithValue("@salary", user.getSalary());
            command.Parameters.AddWithValue("@dob", user.getDob());
            command.Parameters.AddWithValue("@email", user.getEmail());
            command.Parameters.AddWithValue("@mobile", user.getMobileNo());
            command.ExecuteNonQuery();
            connection.Close();
        }
        public EmployeeUser searchEmployee(string search)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where username=@search", con);
            cmd.Parameters.AddWithValue("@search", search);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                EmployeeUser user = new EmployeeUser(reader["dob"].ToString(), reader["salary"].ToString(), reader["email"].ToString(), reader["mobile"].ToString(), reader["role"].ToString(), reader["password"].ToString(), reader["username"].ToString(), reader["name"].ToString());
                con.Close();
                return user;
            }
            return null;
        }
        public EmployeeUser empProfile(string name)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where username=@name", con);
            cmd.Parameters.AddWithValue("@name", name); 
            SqlDataReader reader = cmd.ExecuteReader(); 
            if (reader.Read())
            {
                EmployeeUser user = new EmployeeUser(reader["dob"].ToString(), reader["salary"].ToString(), reader["email"].ToString(), reader["mobile"].ToString(), reader["role"].ToString(), reader["password"].ToString(), reader["username"].ToString(), reader["name"].ToString());
                con.Close();
                return user;
            }
            return null;
        }
        public void announceFreeCamp(string date,string message)
        {
            SqlConnection con = new  SqlConnection(connectionString);
            con.Open();
            string query = String.Format("INSERT INTO FreeCamp(freeCampDate,freeCampMsg) VALUES('{0}', '{1}')", date, message);
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
