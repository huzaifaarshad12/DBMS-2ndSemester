using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.BL
{
    public class Medicine
    {
        private string medicineName;
        private string company;
        private string expiryDate;
        private int price;
        private int quantity;
        private string distributor;

        public Medicine(string medicineName, string company, string expiryDate, int price, int quantity, string distributor)
        {
            this.medicineName = medicineName;
            this.company = company;
            this.expiryDate = expiryDate;
            this.price = price;
            this.quantity = quantity;
            this.distributor = distributor;
        }
        public Medicine(string medicineName)
        {
            this.medicineName = medicineName;
        }
        public string getMedicineName()
        {
            return medicineName;
        }
        public string getCompany()
        {
            return company;
        }
        public string getExpiryDate()
        {
            return expiryDate;
        }
        public int getPrice()
        {
            return price;
        }
        public int getQuantity()
        {
            return quantity;
        }
        public string getDistributor()
        {
            return distributor;
        }

    }
}
