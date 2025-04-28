using Dll.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Generic
{
    public interface IMUserStore
    {
        MUser SignIn(MUser user);
        bool SignUp(MUser user);
        bool changePassord(string username, string oldPass, string newPass);
        List<MUser> getAllUsers();
        MUser viewProfile(string name);
        void updateProfile(MUser user);

    }
}
