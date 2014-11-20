using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PMI31CourseProject;
using DAL;
using BLL;
using ProgramingDeptMVC.Models;

namespace ProgramingDeptMVC.Controllers
{
    public class HomeController: Controller
    {
        //
        // GET: /Home/
        ManageUsers manager = new ManageUsers();
        public ViewResult SignIn()
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

        public ViewResult PersonalM()
        {
            ViewBag.Title = "Маркіян Фостяк";
            return View();
        }

        public ViewResult AboutM()
        {
            return View();
        }

        public ViewResult ContactM()
        {
            return View();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult HomePage()
        {
            return View();
        }

        public ViewResult News()
        {
            return View();
        }

        public ViewResult History()
        {
            return View();
        }

        public ViewResult Gig()
        {
            return View();
        }

        public ViewResult NewsHome()
        {
            return View();
        }

        public ViewResult HistoryHome()
        {
            return View();
        }

        public ViewResult GigHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginModel resultOfLogin)
        {
            switch (resultOfLogin.AuthenticationCheck(manager))
            {
                case AuthenticationStatus.Graduate:
                    return Redirect(@"HomePage");
                    break;
                case AuthenticationStatus.Lecturer:
                    if (resultOfLogin.username == "yuran")
                    {
                        return Redirect(@"HomePage");
                    }
                    else
                    {
                        return Redirect(@"HomePage");
                    }
                    break;
                case AuthenticationStatus.Administrator:
                if (resultOfLogin.username == "yuran")
                    {
                        return Redirect(@"HomePage");
                    }
                    else
                    {
                        return Redirect(@"HomePage");
                    }
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
        public ActionResult Register(RegistrationModel registration)
        {
            
            switch (registration.RegistrationCheck(manager))
            {
                case RegistrationStatus.RegistratedGraduate:
                    return Redirect(@"HomePage");
                    break;
                case RegistrationStatus.RegistratedLecturer:
                    return Redirect(@"HomePage");
                    break;
                case RegistrationStatus.Failed:
                    return Redirect(@"#");
                    break;
                default:
                    return Redirect(@"#");
            }
        }
    }
}
