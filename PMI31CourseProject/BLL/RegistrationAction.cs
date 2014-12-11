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
    /// class Registration Action
    /// </summary>
    public class RegistrationAction
    {
        /// <summary>
        /// user name of class RegistrationAction
        /// </summary>
        public string username { get; set; }
        
        /// <summary>
        /// password of class RegistrationAction
        /// </summary>
        public string password { get; set; }
        
         /// <summary>
        /// email of class RegistrationAction
        /// </summary>
        public string email { get; set; }
        
        /// <summary>
        /// full Name user of class RegistrationAction
        /// </summary>
        public string fullName { get; set; }
        
         /// <summary>
        /// role user of class RegistrationAction
        /// </summary>
        public Role role { get; set; }

        /// <summary>
        /// check role is graduate
        /// </summary>
        /// <returns>rue if role is graduate</returns>
        public bool CheckRoleIsGraduate()
        {
            if (this.role == Role.Graduate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// check role is Lecturer
        /// </summary>
        /// <returns>true if role is lecturer</returns>
        public bool CheckRoleIsLecturer()
        {
            if (this.role == Role.Lecturer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// set role for user
        /// </summary>
        /// <param name="roleName">role for user</param>
        public void SetRoleForUser(ref string roleName)
        {
            if (CheckRoleIsGraduate())
            {
                roleName = "graduate";
            }
            else
            {
                if (CheckRoleIsLecturer())
                {
                    roleName = "lecturer";
                }
            }
        }

        /// <summary>
        /// set registration
        /// </summary>
        /// <returns>set registration status for user</returns>
        public RegistrationStatus SetRegistrationStatus()
        {
            if (CheckRoleIsGraduate())
            {
                return RegistrationStatus.RegistratedGraduate;
            }
            else
            {
                if (CheckRoleIsLecturer())
                {
                    return RegistrationStatus.RegistratedLecturer;
                }
                else
                {
                    return RegistrationStatus.Failed;
                }
            }
        }

        /// <summary>
        /// This method Registration Check users
        /// </summary>
        /// <param name="users">Users to check.</param>
        /// <returns>Status of registration</returns>
        public RegistrationStatus RegistrationCheck(ManageUsers users)
        {
            User regUser;
            regUser = users.GetById(username);
            if (regUser == null)
            {
                return RegistrationStatus.Failed;
            }
            else
            {
                regUser = new User();
                regUser.Login = username;
                regUser.Password = Security.HashPassword(password);
                regUser.FullName = fullName;
                string roleName = string.Empty;
                this.SetRoleForUser(ref roleName);
                regUser.Role = roleName;
                users.AddUser(regUser);
                regUser.IsRegistered = true;
                regUser.UserInfo = new UserInfo();
                return SetRegistrationStatus();
            }
        }
    }
}
