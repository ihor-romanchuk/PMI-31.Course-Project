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
        /// This method Registration Check users
        /// </summary>
        /// <param name="users">Users to check.</param>
        /// <returns>Status of registration.</returns>
        public RegistrationStatus RegistrationCheck(ManageUsers users)
        {
            User regUser;
            regUser = users.GetById(username);
            if (regUser != null)
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
                if (this.role == Role.Graduate)
                {
                    roleName = "graduate";
                }
                if (this.role == Role.Lecturer)
                {
                    roleName = "lecturer";
                }
                regUser.Role = roleName;
                users.AddUser(regUser);
                regUser.IsRegistered = true;
                regUser.UserInfo = new UserInfo();
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
