using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PMI31CourseProject;
using ProgramingDeptMVC.Models;
using DAL;
namespace ProgramingDeptMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Course_ProjectEntities db = new Course_ProjectEntities();
        public ActionResult Index()
        {
            @ViewBag.Title = "Головна";
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Title = "Register";
            return View();
        }
        [HttpPost]
        public string Index(LoginAction resultOfLoginAction)
        {

            string message = string.Empty;
            using (UnitOfWork<UserOfSite> un = new UnitOfWork<UserOfSite>())
            {
                UserOfSite us = new UserOfSite();
                us.login = resultOfLoginAction.username;
                us.password = resultOfLoginAction.password;
                us.role = "admin";
                un.ContactRepository.Add(us);
                un.Save();
                IEnumerable<UserOfSite> col = un.ContactRepository.GetAll();
                foreach (UserOfSite it in col)
                {
                    message += it.login;
                }
            }
            return message;
            //switch (resultOfLoginAction.AuthenticationCheck(db))
            //{
            //    case AuthenticationStatus.Graduate:
            //        message = "Вітаємо! Ви увійшли як випускник.";
            //        break;
            //    case AuthenticationStatus.Lecturer:
            //        message = "Вітаємо! Ви увійшли як викладач.";
            //        break;
            //    case AuthenticationStatus.Administrator:
            //        message = "Вітаємо! Ви увійшли як адміністратор.";
            //        break;
            //    case AuthenticationStatus.NoUser:
            //        message = "На жаль, користувача з таким ім'ям не зареєстровано.";
            //        break;
            //    case AuthenticationStatus.WrongPassword:
            //        message = "Ви ввели не вірний пароль.";
            //        break;
            //}
            
        }

        [HttpPost]
        public string Register(RegistrationAction registration)
        {
            string message = string.Empty;
            switch (registration.RegistrationCheck(db))
            {
                case RegistrationStatus.RegistratedGraduate:
                    message = "Ви зареєструвалися як випускник.";
                    break;
                case RegistrationStatus.RegistratedLecturer:
                    message = "Ви зареєструвалися як викладач.";
                    break;
                case RegistrationStatus.Failed:
                    message = "Користувач з таким іменем уже зарестрований.";
                    break;
            }
            return message;
        }
    }
}
