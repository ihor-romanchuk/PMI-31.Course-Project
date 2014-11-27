using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using DAL;
using System.Linq.Expressions;

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
                contactEntity.password = Security.HashPassword(user.password);
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

        public List<Graduate> GetAllUsersByGraduateYear(System.DateTime year)
        {
            List<Graduate> users = new List<Graduate>();
            using (UnitOfWork<Graduate> unitOfWork = new UnitOfWork<Graduate>())
            {
                Expression<Func<Graduate, bool>> expr = G => G.year_of_graduation == year;
                users = unitOfWork.ContactRepository.GetMany(expr).ToList<Graduate>();
            }
            return users;
        }

        public List<Graduate> GetAllUsersByGraduateName(string name)
        {
            List<Graduate> users = new List<Graduate>();
            using (UnitOfWork<Graduate> unitOfWork = new UnitOfWork<Graduate>())
            {
                Expression<Func<Graduate, bool>> expr = G => G.name == name;
                users = unitOfWork.ContactRepository.GetMany(expr).ToList<Graduate>();
            }
            return users;
        }

        public List<Graduate> GetAllUsersByGraduateSurName(string surName)
        {
            List<Graduate> users = new List<Graduate>();
            using (UnitOfWork<Graduate> unitOfWork = new UnitOfWork<Graduate>())
            {
                Expression<Func<Graduate, bool>> expr = G => G.surname == surName;
                users = unitOfWork.ContactRepository.GetMany(expr).ToList<Graduate>();
            }
            return users;
        }

        public List<Lecturer> GetAllUsersByLecturerName(string name)
        {
            List<Lecturer> users = new List<Lecturer>();
            using (UnitOfWork<Lecturer> unitOfWork = new UnitOfWork<Lecturer>())
            {
                Expression<Func<Lecturer, bool>> expr = G => G.name == name;
                users = unitOfWork.ContactRepository.GetMany(expr).ToList<Lecturer>();
            }
            return users;
        }

        public List<Lecturer> GetAllUsersByLecturerSurName(string surName)
        {
            List<Lecturer> users = new List<Lecturer>();
            using (UnitOfWork<Lecturer> unitOfWork = new UnitOfWork<Lecturer>())
            {
                Expression<Func<Lecturer, bool>> expr = G => G.surname == surName;
                users = unitOfWork.ContactRepository.GetMany(expr).ToList<Lecturer>();
            }
            return users;
        }

        public List<Lecturer> GetAllUsersByLecturerSubject(string subject)
        {
            List<Lecturer> users = new List<Lecturer>();
            using (UnitOfWork<Lecturer> unitOfWork = new UnitOfWork<Lecturer>())
            {
                Expression<Func<Lecturer, bool>> expr = G => G.subject == subject;
                users = unitOfWork.ContactRepository.GetMany(expr).ToList<Lecturer>();
            }
            return users;
        }
    }
}
