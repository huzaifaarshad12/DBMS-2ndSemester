using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.Generic;
using Dll.DL;
using Dll.Utilities;
using System.Data.SqlClient;

namespace Dll.BL
{
     
    public class MUser
    {
        protected string userName;
        protected string userPassword;
        protected string userRole;
        protected string name;

        public MUser(string userName, string userPassword, string userRole, string name) : this(userName, userPassword, userRole)
        {
            this.name = name;
        }

        public MUser(string userName, string userPassword, string userRole)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = userRole;
        }

        public MUser(string userName, string userPassword)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = "NA";
        }

        public  string getUserName()
        {
            return userName;
        }
        public string getName()
        {
            return name;
        }
        public string getUserPassword()
        {
            return userPassword;
        }

        public string getUserRole()
        {
            return userRole;
        }
        public bool isAdmin()
        {
            if (userRole == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
