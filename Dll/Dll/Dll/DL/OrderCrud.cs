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
    public class OrderCrud : IOrder
    {
        string conn=utility.getconnString();
        private static OrderCrud instance;
        private OrderCrud(string connection)
        {
            this.conn=connection;
        }
        public static OrderCrud getInstance(string connection)
        {
            if(instance==null)
            {
                instance=new OrderCrud(connection);
            }
            return instance;
        }
        public bool validateOrder(Order o)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = String.Format("select * from customerOrder WHERE orderID = @orderId");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId", o.getOrderID());
            SqlDataReader reader = command.ExecuteReader();
            bool check = reader.Read();
            connection.Close();
            return check;
        }
        public bool addOrder(Order order)
        {
            if (!validateOrder(order))
            {
                SqlConnection connection = new SqlConnection(conn);
                connection.Open();
                string query = String.Format("INSERT INTO customerOrder(orderID,customerID,customerName,orderDate,totalAmount) VALUES('{0}', '{1}', '{2}' , '{3}' , '{4}')", order.getOrderID(), order.getCustomerID(), order.getCustomerName(), order.getOrderDate(), order.getTotalAmount());
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }
        public List<Order> getSaleRecord()
        {
            SqlConnection connection= new SqlConnection(conn);
            connection.Open();
            string query = "SELECT * FROM customerOrder";
            SqlCommand command = new SqlCommand(query, connection);
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
