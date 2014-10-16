using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProgramingDeptMVC.Models;

namespace ProgramingDeptMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            @ViewBag.Title = "Головна";
            return View();
        }
        [HttpPost]
        public string Index(LoginAction resultOfLoginAction)
        {
            string message = string.Empty;
            switch (resultOfLoginAction.AuthenticationCheck())
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
                    message = "На жаль, користувача.";
                    break;
                case AuthenticationStatus.WrongPassword:
                    message = "Íà æàëü, âè ââåëè íåâ³ðíèé ïàðîëü.";
                    break;
            }
            return message;
        }
    }
}
