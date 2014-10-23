using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using DAL;

namespace BLL
{
    public class ManageUsers
    {
        public IEnumerable<UserOfSite> GetContacts()
        {
            IEnumerable<UserOfSite> users;
            using (UnitOfWork<UserOfSite> unitOfWork = new UnitOfWork<UserOfSite>())
            {
                users = unitOfWork.ContactRepository.GetAll();
            }
            return users;
        }

        public bool AddUser(UserOfSite user)
        {
            using (UnitOfWork<UserOfSite> unitOfWork = new UnitOfWork<UserOfSite>())
            {
                unitOfWork.ContactRepository.Add(user);
                unitOfWork.Save();
            }
            return true;
        }

        public bool UpdateUser(UserOfSite user, string id)
        {
            using (UnitOfWork<UserOfSite> unitOfWork = new UnitOfWork<UserOfSite>())
            {
                var contactEntity = unitOfWork.ContactRepository.GetById(id);
                contactEntity.login = user.login;
                contactEntity.password = user.password;
                contactEntity.role = user.role;
                unitOfWork.Save();
            }
            return true;
        }

        public bool DeleteUser(string id)
        {
            using (UnitOfWork<UserOfSite> unitOfWork = new UnitOfWork<UserOfSite>())
            {
                UserOfSite user = unitOfWork.ContactRepository.GetById(id);
                unitOfWork.ContactRepository.Delete(user);
                unitOfWork.Save();
            }
            return true;
        }

        public UserOfSite GetById(string id)
        {
            UserOfSite user;
            using (UnitOfWork<UserOfSite> unitOfWork = new UnitOfWork<UserOfSite>())
            {
                user = unitOfWork.ContactRepository.GetById(id);
            }
            return user;
        }
    }
}
