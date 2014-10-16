using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMI31CourseProject;

namespace ProgramingDeptMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private Course_ProjectEntities context = new Course_ProjectEntities();

        public ActionResult Index()
        {
            ViewBag.Title = "Головна";
            return View();
        }

        [HttpPost]
        public string Index(AuthenticationStatus status)
        {
            string message = string.Empty;
            switch (status)
            {
                case AuthenticationStatus.Graduate:
                    message = "Вітаємо! Ви зайшли як випускник.";
                    break;
                case AuthenticationStatus.Lecturer:
                    message = "Вітаємо! Ви зайшли як викладач.";
                    break;
                case AuthenticationStatus.Administrator:
                    message = "Вітаємо! Ви зайшли як адміністратор.";
                    break;
                case AuthenticationStatus.NoUser:
                    message = "На жаль, користувач з таким ім'ям не зареєстрований.";
                    break;
                case AuthenticationStatus.WrongPassword:
                    message = "На жаль, ви ввели невірний пароль.";
                    break;
            }
            return message;
        }
    }
}
