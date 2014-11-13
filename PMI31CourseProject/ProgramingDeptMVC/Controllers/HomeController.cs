using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PMI31CourseProject;
using DAL;
using BLL;
namespace ProgramingDeptMVC.Controllers
{
    public class HomeController: Controller
    {
        //
        // GET: /Home/
        ManageUsers manager = new ManageUsers();
        public ViewResult Index()
        {
            @ViewBag.Title = "Головна";
            return View();
        }
        public ViewResult Register()
        {
            ViewBag.Title = "Register";
            return View();
        }

        public ViewResult Personal()
        {
            ViewBag.Title = "Юра Плоский";
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginAction resultOfLoginAction)
        {
            switch (resultOfLoginAction.AuthenticationCheck(manager))
            {
                case AuthenticationStatus.Graduate:
                    return Redirect(@"Home\Personal");
                    break;
                case AuthenticationStatus.Lecturer:
                    return Redirect(@"Home\Personal");
                    break;
                case AuthenticationStatus.Administrator:
                    return Redirect(@"Home\Personal");
                    break;
                case AuthenticationStatus.NoUser:
                    return Redirect(@"#");
                    break;
                case AuthenticationStatus.WrongPassword:
                    return Redirect(@"#");
                    break;
                default:
                    return Redirect(@"#");

            }
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
