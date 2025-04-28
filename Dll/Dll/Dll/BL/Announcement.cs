using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.Generic;
using Dll.Utilities;


namespace Dll.BL
{
    public class Announcement
    {
        string conn = utility.getconnString();
        private string date;
        private string message;
        public Announcement( string date, string message)
        {
            this.date = date;
            this.message = message;
        }
        public string getDate()
        {
            return date;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
