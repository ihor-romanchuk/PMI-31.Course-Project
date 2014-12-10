using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using ProjectDatabase;

namespace BLL
{
    /// <summary>
    /// class LoginAction
    /// </summary>
    public class LoginAction
    {
         /// <summary>
        /// get and set user name
        /// </summary>
        public string username { get; set; }
        
        /// <summary>
        /// get and set password user
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// constructor 
        /// </summary>
        public LoginAction()
        {
            username = string.Empty;
            password = string.Empty;
        }
        
        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pswrd"></param>
        public LoginAction(string uname, string pswrd)
        {
            username = uname;
            password = pswrd;
        }

        /// <summary>
        /// method authentication check
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public AuthenticationStatus AuthenticationCheck(ManageUsers users)
        {
            User loggingUser = users.GetById(username);
            if (loggingUser != null)
            {
                if (loggingUser.Password != Security.HashPassword(this.password))
                {
                    return AuthenticationStatus.WrongPassword;
                }
                if (loggingUser.Role == "admin")
                {
                    return AuthenticationStatus.Administrator;
                }
                if (loggingUser.Role == "graduate")
                {
                    return AuthenticationStatus.Graduate;
                }
                if (loggingUser.Role == "lecturer")
                {
                    return AuthenticationStatus.Lecturer;
                }
            }
            return AuthenticationStatus.NoUser;
        }
    }
}
