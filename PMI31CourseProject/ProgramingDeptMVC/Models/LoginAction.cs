using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMI31CourseProject;
using PMI31CourseProject.Repository;

namespace ProgramingDeptMVC.Models
{
    public class LoginAction
    {
        public string username { get; set; }
        public string  password { get; set; }

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

        public AuthenticationStatus AuthenticationCheck(Course_ProjectEntities entities)
        {
            Repository<Graduate> graduates = new Repository<Graduate>(entities);
            Repository<Lecturer> lecturers = new Repository<Lecturer>(entities);
            Repository<Administrator> admins = new Repository<Administrator>(entities);
            Graduate enterinGraduate = graduates.GetById(username);
            Lecturer enteringLecturer = lecturers.GetById(username);
            Administrator enteringAdministrator = admins.GetById(username);
            if (enterinGraduate != null)
            {
                return AuthenticationStatus.Graduate;
            }
            if (enteringLecturer != null)
            {
                return AuthenticationStatus.Lecturer;
            }
            if (enteringAdministrator != null)
            {
                if (enteringAdministrator.password == this.password)
                {
                    return AuthenticationStatus.Administrator;
                }
                else
                {
                    return AuthenticationStatus.WrongPassword;
                }
            }
            else
            {
                return AuthenticationStatus.NoUser;
            }
        }
    }
}