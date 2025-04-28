using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.Generic;
using Dll.DL;

namespace Dll.BL
{
    public class Feedback
    {
        private string feedBackMsg;
        public Feedback(string feedBackMsg)
        {
            this.feedBackMsg = feedBackMsg;
        }
        public string getFeedBackMsg()
        {
            return feedBackMsg;
        }
    }
}
