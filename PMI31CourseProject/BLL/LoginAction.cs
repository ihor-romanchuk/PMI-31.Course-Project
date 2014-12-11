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
    /// Class for representing login action
    /// </summary>
    public class LoginAction
    {
        /// <summary>
        /// Property for representing user name
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Property for representing user password
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginAction()
        {
            UserLogin = string.Empty;
            UserPassword = string.Empty;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="uname">user name</param>
        /// <param name="pswrd">user password</param>
        public LoginAction(string uname, string pswrd)
        {
            UserLogin = uname;
            UserPassword = pswrd;
        }

        /// <summary>
        /// Get AuthenticationStatus for user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>AuthenticationStatus for user</returns>
        public AuthenticationStatus GetAuthenticationStatusForUser(User user)
        {
            string temp1 = user.Password;
            string temp2 = Security.HashPassword(this.UserPassword);
            if (user.Password.CompareTo( Security.HashPassword(this.UserPassword)) != 0)
            {
                return AuthenticationStatus.WrongPassword;
            }
            else
                if (user.Role == "admin")
                {
                    return AuthenticationStatus.Administrator;
                }
                else
                    if (user.Role == "graduate")
                    {
                        return AuthenticationStatus.Graduate;
                    }
                    else
                        if (user.Role == "lecturer")
                        {
                            return AuthenticationStatus.Lecturer;
                        }
                        else
                        {
                            return AuthenticationStatus.NoUser;
                        }
        }

        /// <summary>
        /// AuthentificationCheck method for get AuthenticationStatus
        /// </summary>
        /// <param name="user">parameter for connecting with database</param>
        /// <returns>AuthenticationStatus for user with parameters: UserName, UserPassword</returns>
        public AuthenticationStatus AuthenticationCheck(ManageUsers user)
        {
            User loggingUser = user.GetById(UserLogin);
            if (loggingUser != null)
            {
                return GetAuthenticationStatusForUser(loggingUser);
            }
            else
            {
                return AuthenticationStatus.NoUser;
            }
        }
    }
}
