using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
namespace BLL
{
    public class RegistrationAction
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Role role { get; set; }

        public RegistrationStatus RegistrationCheck(ManageUsers users)
        {
            UserOfSite regUser;
            regUser = users.GetById(username);
            if (regUser != null)
            {
                return RegistrationStatus.Failed;
            }
            else
            {
                regUser = new UserOfSite();
                regUser.login = username;
                regUser.password = password;
                string roleName = string.Empty;
                if (this.role == Role.Graduate)
                {
                    roleName = "graduate";
                }
                if (this.role == Role.Lecturer)
                {
                    roleName = "lecturer";
                }
                regUser.role = roleName;
                users.AddUser(regUser);
                if (this.role == Role.Graduate)
                {
                    return RegistrationStatus.RegistratedGraduate;
                }
                if (this.role == Role.Lecturer)
                {
                    return RegistrationStatus.RegistratedLecturer;
                }
                else
                {
                    return RegistrationStatus.Failed;
                }
            }
        }
    }
}
