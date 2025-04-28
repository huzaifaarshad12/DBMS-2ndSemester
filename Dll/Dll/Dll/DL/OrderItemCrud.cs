using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.BL;
using System.Data.SqlClient;
using Dll.Generic;
using Dll.Utilities;


namespace Dll.DL
{
    public class OrderItemCrud : IorderItems
    {
        string conn=utility.getconnString();
        private static OrderItemCrud instance;
        private OrderItemCrud(string connection)
        {
            this.conn=connection;
        }
        public static OrderItemCrud getInstance(string connection)
        {
            if(instance==null)
            {
                instance=new OrderItemCrud(connection);
            }
            return instance;
        }
        public bool addOrderItem(OrderItems orderItem)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = String.Format("INSERT INTO items(orderID,medicineName,quantity,price) VALUES('{0}', '{1}', '{2}' , '{3}')", orderItem.getOrderID(), orderItem.getMedicineName(), orderItem.getQuantity(), orderItem.getPrice());
            string updateStockQuery = String.Format("UPDATE medicine SET quantity = quantity - {0} WHERE medicineName = '{1}'", orderItem.getQuantity(), orderItem.getMedicineName());
            SqlCommand command = new SqlCommand(query, connection);
            SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection);
            updateStockCommand.ExecuteNonQuery();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        public List<OrderItems> getOrderItemsByOrderID() 
        {
            SqlConnection connection= new SqlConnection(conn);
            connection.Open();
            // using foriegn key concept to get the order items from the order table
            string query = "SELECT orderID AS Order ID,Medicine Name AS Medicine,price AS Price,quantity AS Quantity FROM items WHERE orderID = (SELECT orderID FROM customerOrder)";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<OrderItems> orderItems = new List<OrderItems>();
            while (reader.Read())
            {
                OrderItems orderItem = new OrderItems(reader["orderID"].ToString(), reader["medicineName"].ToString(), Convert.ToInt32(reader["quantity"]), Convert.ToInt32(reader["price"]));
                orderItems.Add(orderItem);
            }
            connection.Close();
            return orderItems;
        }
    }
}
