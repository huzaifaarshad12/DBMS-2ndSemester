using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.BL
{
    public class OrderItems
    {
        private string orderID;
        private string medicineName;
        private int quantity;
        private int price;
        public OrderItems(string orderID, string medicineName, int quantity, int price)
        {
            this.orderID = orderID;
            this.medicineName = medicineName;
            this.quantity = quantity;
            this.price = price;
        }
        public string getOrderID()
        {
            return orderID;
        }
        public string getMedicineName()
        {
            return medicineName;
        }   
        public int getQuantity()
        {
            return quantity;
        }
        public int getPrice()
        {
            return price;
        }


    }
}
