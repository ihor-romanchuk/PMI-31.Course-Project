using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PMI31CourseProject;
using ProgramingDeptMVC.Models;

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
        [HttpPost]
        public string Index(LoginAction resultOfLoginAction)
        {
            string message = string.Empty;
            switch (resultOfLoginAction.AuthenticationCheck(db))
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
    }
}
