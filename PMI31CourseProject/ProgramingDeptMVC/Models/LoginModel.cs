﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using BLL;
namespace ProgramingDeptMVC.Models
{
    public class LoginModel
    {
        public string username { get; set; }
        public string  password { get; set; }

        public LoginModel()
        {
            username = string.Empty;
            password = string.Empty;
        }

        public LoginModel(string uname, string pswrd)
        {
            username = uname;
            password = pswrd;
        }

        public AuthenticationStatus AuthenticationCheck(ManageUsers users)
        {
            UserOfSite loggingUser = users.GetById(username);
            if (loggingUser != null)
            {
                if (loggingUser.password != this.password)
                {
                    return AuthenticationStatus.WrongPassword;
                }
                if (loggingUser.role == "admin")
                {
                    return AuthenticationStatus.Administrator;
                }
                if (loggingUser.role == "graduate")
                {
                    return AuthenticationStatus.Graduate;
                }
                if (loggingUser.role == "lecturer")
                {
                    return AuthenticationStatus.Lecturer;
                }
            }
            return AuthenticationStatus.NoUser;
        }
    }
}