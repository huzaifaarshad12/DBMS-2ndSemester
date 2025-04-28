using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.BL;
using Dll.DL;

namespace Dll.Generic
{
    public interface IOrder
    {
        bool addOrder(Order order);
        List<Order> getSaleRecord();
    }
}
