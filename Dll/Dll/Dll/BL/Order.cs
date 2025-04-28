using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.BL
{
    public class Order
    {
        private string orderID;
        private string customerID;
        private string customerName;
        private string orderDate;
        private int totalAmount;

        public Order(string orderID, string customerID, string customerName, string orderDate, int totalAmount)
        {
            this.orderID = orderID;
            this.customerID = customerID;
            this.customerName = customerName;
            this.orderDate = orderDate;
            this.totalAmount = totalAmount;
        }
        public string getOrderID()
        {
            return orderID;
        }
        public string getCustomerID()
        {
            return customerID;
        }
        public string getCustomerName()
        {
            return customerName;
        }
        public string getOrderDate()
        {
            return orderDate;
        }
        public double getTotalAmount()
        {
            return totalAmount;
        }
    }
}
