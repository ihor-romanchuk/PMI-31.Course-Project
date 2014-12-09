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
    public class ManageUsers
    {
        public IEnumerable<User> GetContacts()
        {
            IEnumerable<User> users;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                users = unitOfWork.ContactRepository.GetAll();
            }
            return users;
        }

        public bool AddUser(User user)
        {
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                unitOfWork.ContactRepository.Add(user);
                unitOfWork.Save();
            }
            return true;
        }

        public bool UpdateUser(User user, string id)
        {
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                var contactEntity = unitOfWork.ContactRepository.GetById(id);
                contactEntity.Login = user.Login;
                contactEntity.Password = Security.HashPassword(user.Password);
                contactEntity.Role = user.Role;
                contactEntity.FullName = user.FullName;
                contactEntity.IsRegistered = user.IsRegistered;
                unitOfWork.Save();
            }
            return true;
        }

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

        public User GetById(string id)
        {
            User user;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                user = unitOfWork.ContactRepository.GetById(id);
            }
            return user;
        }

        public List<User> GetAllUsersByGraduateYear(int year)
        {
            List<User> users = new List<User>();
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                Expression<Func<User, bool>> expr = G => G.UserInfo.GraduateInfo.EntranceYear == year;
                users = unitOfWork.ContactRepository.GetMany(expr).ToList<User>();
            }
            return users;
        }
    }
}
