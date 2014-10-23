using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using DAL;

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

        public AuthenticationStatus AuthenticationCheck(Course_ProjectEntities1 entities)
        {
            UnitOfWork<Admin> unit = new UnitOfWork<Admin>();
            ConnectRepository<Admin> con = unit.ContactRepository;
            Repository<Graduate> graduates = new Repository<Graduate>(entities);
            Repository<Lecturer> lecturers = new Repository<Lecturer>(entities);
            Repository<Admin> admins = new Repository<Admin>(entities);
            //Graduate enterinGraduate = graduates.GetById(username);
            //Lecturer enteringLecturer = lecturers.GetById(username);
            Admin id = new Admin();
            id.login = "odcs";
            id.password = "cdsc";
            con.Add(id);
            unit.Save();
            Admin enteringAdministrator = con.GetById(username);
            /*if (enterinGraduate != null)
            {
                return AuthenticationStatus.Graduate;
            }
            if (enteringLecturer != null)
            {
                return AuthenticationStatus.Lecturer;
            }*/
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