using Dll.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Generic
{
    public interface IorderItems
    {
        bool addOrderItem(OrderItems orderItem);
        List<OrderItems> getOrderItemsByOrderID();


    }
}
