using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using DAL;
using System.Linq.Expressions;
using ProjectDatabase;

namespace BLL
{
     /// <summary>
    /// class Manage Users
    /// </summary>
    public class ManageUsers
    {
         /// <summary>
        /// This method takes users contacts
        /// </summary>
        /// <returns>Collection of users.</returns>
        public IEnumerable<User> GetContacts()
        {
            IEnumerable<User> users;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                users = unitOfWork.ContactRepository.GetAll();
            }
            return users;
        }

        /// <summary>
        /// This method Add User
        /// </summary>
        /// <param name="user">User to add.</param>
        /// <returns>Boolean value, which means if user was added.</returns>
        public bool AddUser(User user)
        {
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                unitOfWork.ContactRepository.Add(user);
                unitOfWork.Save();
            }
            return true;
        }
        
        /// <summary>
        /// This method updates user information.
        /// </summary>
        /// <param name="user">User to upadate</param>
        /// <param name="login">Login of user.</param>
        /// <returns></returns>
        public bool UpdateUser(User user, string id)
        {
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                var contactEntity = unitOfWork.ContactRepository.GetById(GetIdByFullName(id));
                contactEntity.Login = user.Login;
                contactEntity.Password = user.Password;
                contactEntity.Role = user.Role;
                contactEntity.FullName = user.FullName;
                contactEntity.IsRegistered = user.IsRegistered;
                unitOfWork.Save();
            }
            return true;
        }
        
        /// <summary>
        /// This method delete user
        /// </summary>
        /// <param name="login">Login of user to delete</param>
        /// <returns>Boolean value, which means if user was deleted.</returns>
        public bool DeleteUser(string id)
        {
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                User user = unitOfWork.ContactRepository.GetById(id);
                unitOfWork.ContactRepository.Delete(user);
                unitOfWork.Save();
            }
            return true;
        }

        /// <summary>
        /// This method Get Id By Login
        /// </summary>
        /// <param name="login">Login for searching.</param>
        /// <returns>Id of user.</returns>
        public int GetIdByLogin(string login)
        {
            int Id;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                Expression<Func<User, bool>> expr = G => G.Login == login;
                var listOfUsers = unitOfWork.ContactRepository.GetMany(expr).ToList();
                if (listOfUsers.Count == 0)
                {
                    Id = -1;
                }
                else
                {
                    Id = listOfUsers[0].Id;
                }
            }
            return Id;
        }

        public int GetIdByFullName(string userName)
        {
            int Id;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                Expression<Func<User, bool>> expr = G => G.FullName == userName;
                var listOfUsers = unitOfWork.ContactRepository.GetMany(expr).ToList();
                if (listOfUsers.Count == 0)
                {
                    Id = -1;
                }
                else
                {
                    Id = listOfUsers[0].Id;
                }
            }
            return Id;
        }
        /// <summary>
        /// This method Get user By Id
        /// </summary>
        /// <param name="login">Login of user to get.</param>
        /// <returns>User By Id.</returns>
        public User GetById(string login)
        {
            User user;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                user = unitOfWork.ContactRepository.GetById(GetIdByLogin(login));
            }
            return user;
        }

        /// <summary>
        /// Get user By Full Name
        /// </summary>
        /// <param name="FullName">Full Name of user to get</param>
        /// <returns>User By Full Name</returns>
        public User GetByFullName(string FullName)
        {
            User user;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                user = unitOfWork.ContactRepository.GetById(GetIdByFullName(FullName));
            }
            return user;
        }
        /// <summary>
        /// This method Get All Users By Graduate Year
        /// </summary>
        /// <param name="year">Year of graduation to find.</param>
        /// <returns></returns>
        public List<User> GetAllUsersByGraduateYear(int graduationYear)
        {
            List<User> users = new List<User>();
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                Expression<Func<User, bool>> expressionForGetAllUsersByGraduateYear = user => user.UserInfo.GraduateInfo.GraduationYear == graduationYear;
                users = unitOfWork.ContactRepository.GetMany(expressionForGetAllUsersByGraduateYear).ToList<User>();
            }
            return users;
        }

        /// <summary>
        /// Get list of all users by entrance year
        /// </summary>
        /// <param name="entranceYear">users entrance year</param>
        /// <returns>list of all users by entrance year</returns>
        public List<User> GetAllUsersByEntranceYear(int entranceYear)
        {
            List<User> users = new List<User>();
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                Expression<Func<User, bool>> expressionForGetAllUsersByEntranceYear = user => user.UserInfo.GraduateInfo.EntranceYear == entranceYear;
                users = unitOfWork.ContactRepository.GetMany(expressionForGetAllUsersByEntranceYear).ToList<User>();
            }
            return users;
        }

        /// <summary>
        /// Get list of all users by speciality
        /// </summary>
        /// <param name="entranceYear">users speciality</param>
        /// <returns>list of all users by speciality</returns>
        public List<User> GetAllUsersBySpeciality(string speciality)
        {
            List<User> users = new List<User>();
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                Expression<Func<User, bool>> expressionForGetAllUsersBySpeciality = user => user.UserInfo.GraduateInfo.Speciality == speciality;
                users = unitOfWork.ContactRepository.GetMany(expressionForGetAllUsersBySpeciality).ToList<User>();
            }
            return users;
        }
    }
}
