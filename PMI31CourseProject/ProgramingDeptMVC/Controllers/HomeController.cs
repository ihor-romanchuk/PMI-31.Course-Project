using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PMI31CourseProject;
using ProgramingDeptMVC.Models;
using DAL;
using BLL;
namespace ProgramingDeptMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ManageUsers manager = new ManageUsers();
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
            switch (resultOfLoginAction.AuthenticationCheck(manager))
            {
                case AuthenticationStatus.Graduate:
                    message = "Вітаємо! Ви увійшли як випускник.";
                    break;
                case AuthenticationStatus.Lecturer:
                    message = "Вітаємо! Ви увійшли як викладач.";
                    break;
                case AuthenticationStatus.Administrator:
                    message = "Вітаємо! Ви увійшли як адміністратор.";
                    break;
                case AuthenticationStatus.NoUser:
                    message = "На жаль, користувача з таким ім'ям не зареєстровано.";
                    break;
                case AuthenticationStatus.WrongPassword:
                    message = "Ви ввели не вірний пароль.";
                    break;
            }
            return message;

        }

        [HttpPost]
        public string Register(RegistrationAction registration)
        {
            string message = string.Empty;
            switch (registration.RegistrationCheck(manager))
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
