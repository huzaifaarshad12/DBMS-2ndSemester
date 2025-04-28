using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.BL
{
    public class Customer :MUser
    {
        public Customer(string userName, string userPassword, string userRole,string name) :base( userName,  userPassword,  userRole,name)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = userRole;
            this.name = name;
        }
        
    }
}
