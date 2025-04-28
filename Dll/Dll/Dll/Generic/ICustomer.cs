using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.BL;
namespace Dll.Generic
{
    public interface ICustomer
    {
        bool addCustomer(Customer user);
        void delCustomer(Customer user);
        List<Customer> getCustomerData();
        List<Order> getMedicineBuyRecord(string name);
    }
}
