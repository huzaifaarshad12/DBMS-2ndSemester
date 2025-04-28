using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.BL
{
    public class EmployeeUser : MUser
    {
        private string dob;
        private string salary;
        private string email;
        private string mobileNo;
        public EmployeeUser(string dob, string salary, string email, string mobileNo,string userRole,string userPassword,string userName,string name):base(userRole,userPassword,userName,name)
        { 
            this.dob = dob;
            this.salary = salary;
            this.email = email;
            this.mobileNo = mobileNo;
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = userRole;
            this.name = name;
        }
        
        public string getDob()
        {
            return dob;
        }
        public string getSalary()
        {
            return salary;
        }
        public String getEmail() {
            return email;
        }
        public string getMobileNo()
        {
            return mobileNo;
        }
        
    }
    
}
