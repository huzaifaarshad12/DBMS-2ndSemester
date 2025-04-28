using Dll.BL;
using Dll.Generic;
using Dll.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dll.DL
{
    public class MuserDBStore : IMUserStore
    {
       
        public string connectionString = utility.getconnString();
        static MuserDBStore instance;
        private MuserDBStore(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public static MuserDBStore getInstance(string connectionString)
        {
            if(instance==null)
            {
                instance = new MuserDBStore(connectionString);
            }
            return instance;
        }
        public MUser SignIn(MUser user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string searchQuery = String.Format("Select * from Users where username = '{0}' and password = '{1}'", user.getUserName(), user.getUserPassword());
            SqlCommand command = new SqlCommand(searchQuery, connection);
            SqlDataReader data = command.ExecuteReader();
            if (data.Read())
            {
                string username = data.GetString(0);
                string password = data.GetString(1);
                string role = data.GetString(2);

                MUser user1 = new MUser(username, password, role);
                connection.Close();
                return user1;
            }
            connection.Close();
            return null;
        }
        public static bool validateUser(MUser user, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string searchQuery = String.Format("Select * from Users where username = '{0}'", user.getUserName());
            SqlCommand command = new SqlCommand(searchQuery, connection);
            SqlDataReader data = command.ExecuteReader();
            bool check = data.Read();
            connection.Close();
            return check;
            
        }
        
        public bool SignUp(MUser user)
        {
            if (!validateUser(user, connectionString))
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = String.Format("INSERT INTO Users(username,password,role,name) VALUES('{0}','{1}','{2}','{3}')", user.getUserName(), user.getUserPassword(), user.getUserRole(),user.getName());
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
              }
            
            return false;
        }
        
        public List<MUser> getAllUsers()
        {
            List<MUser> usersList = new List<MUser>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Users";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MUser user = new MUser(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                usersList.Add(user);
            }
            connection.Close();
            return usersList;
        }
        private bool validatePassword(MUser user, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("SELECT * FROM Users WHERE username = '{0}' AND password = '{1}'", user.getUserName(), user.getUserPassword());
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public bool changePassord(string username, string oldPass, string newPass)
        {
            MUser user = new MUser(username, oldPass);
            if (validatePassword(user, connectionString))
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = String.Format("UPDATE Users SET password = '{0}' WHERE username = '{1}'", newPass, username);
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }
        public MUser viewProfile(string Name)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where username=@name", con);
            cmd.Parameters.AddWithValue("@name", Name);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MUser user = new MUser(reader["username"].ToString(), reader["password"].ToString(), reader["role"].ToString(), reader["name"].ToString());
                con.Close();
                return user;
            }
            return null;
        }
        public void updateProfile(MUser user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = string.Format("Update Users set name=@name,password=@password,role=@role where username = @username");
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", user.getUserName());
            cmd.Parameters.AddWithValue("@role", user.getUserRole());
            cmd.Parameters.AddWithValue("@password", user.getUserPassword());
            cmd.Parameters.AddWithValue("@name", user.getName());
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        public List<MUser> getCustomerData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Users WHERE role = 'Customer'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<MUser> users = new List<MUser>();
            while (reader.Read())
            {
                MUser user = new MUser(reader["username"].ToString(), reader["password"].ToString(), reader["role"].ToString(), reader["name"].ToString());
                users.Add(user);
            }
            connection.Close();
            return users;
        }
        
    }
}
