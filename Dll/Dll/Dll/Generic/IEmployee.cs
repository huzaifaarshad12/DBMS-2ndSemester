using Dll.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Generic
{
    public interface IEmployee
    {
        bool addEmployee(EmployeeUser user);
        void delEmployee(EmployeeUser user);
        void updateEmployee(EmployeeUser user);
        EmployeeUser searchEmployee(string name);
        EmployeeUser empProfile(string name);
        List<EmployeeUser> getEmployeeData();
    }
}
