﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using ProjectDatabase;

namespace BLL
{
    public class LoginAction
    {
        public string username { get; set; }
        public string password { get; set; }

        public LoginAction()
        {
            username = string.Empty;
            password = string.Empty;
        }

        public LoginAction(string uname, string pswrd)
        {
            username = uname;
            password = pswrd;
        }

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
