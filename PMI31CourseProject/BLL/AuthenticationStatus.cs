using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
     /// <summary>
    /// enum Authentication Status which includes parameters such as
    ///WrongPassword,NoUser,Graduate,Lecturer,Administrator
    /// </summary>
    public enum AuthenticationStatus
    {
        WrongPassword, NoUser, Graduate, Lecturer, Administrator
    }
}
