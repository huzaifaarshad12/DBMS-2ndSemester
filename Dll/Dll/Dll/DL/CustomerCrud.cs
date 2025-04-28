using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.BL;
using Dll.Generic;
using Dll.Utilities;
using System.Data.SqlClient;

namespace Dll.DL
{
    public class CustomerCrud : ICustomer
    {
        string conn = utility.getconnString();
        static CustomerCrud instance;
        private CustomerCrud(string conn)
        {
            this.conn = conn;
        }
        public static CustomerCrud getInstance(string conn)
        {
            if (instance == null)
            {
                instance = new CustomerCrud(conn);
            }
            return instance;
        }
        public bool addCustomer(Customer user)
        {
            if (!(MuserDBStore.validateUser(user, conn)))
            {
                SqlConnection connection = new SqlConnection(conn);
                connection.Open();
                string query = String.Format("INSERT INTO Users(username,password,role,name) VALUES('{0}', '{1}', '{2}' , '{3}')", user.getUserName(), user.getUserPassword(), user.getUserRole(), user.getName());
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }
        public void delCustomer(Customer user)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = String.Format("DELETE FROM Users WHERE username = '{0}'", user.getUserName());
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Customer> getCustomerData()
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "SELECT * FROM Users WHERE role = 'Customer'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Customer> users = new List<Customer>();
            while (reader.Read())
            {
                Customer user = new Customer(reader["username"].ToString(), reader["password"].ToString(), reader["role"].ToString(), reader["name"].ToString());
                users.Add(user);
            }
            connection.Close();
            return users;
        }
        public List<Order> getMedicineBuyRecord(string name)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "SELECT * FROM customerOrder where customerID=@name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                Order order = new Order(reader["orderID"].ToString(), reader["customerID"].ToString(), reader["customerName"].ToString(), reader["orderDate"].ToString(), Convert.ToInt32(reader["totalAmount"]));
                orders.Add(order);
            }
            connection.Close();
            return orders;
        }
    }
}
