using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Utilities
{
    public  class utility
    {
       private static string connString = "Data Source=DESKTOP-F4N727V;Initial Catalog=project;Integrated Security=True;";
        public static  string getconnString()
        {
           return connString;     
        }
    }
}
