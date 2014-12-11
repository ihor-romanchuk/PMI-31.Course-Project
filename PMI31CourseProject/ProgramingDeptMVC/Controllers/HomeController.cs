using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PMI31CourseProject;
using DAL;
using BLL;
using ProgramingDeptMVC.Models;
using ProjectDatabase;

namespace ProgramingDeptMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ManageUsers manager = new ManageUsers();
        public ViewResult SignIn()
        {
            ViewBag.Title = "Головна";
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

        public ViewResult FindGraduatesByYear()
        {
            return View();
        }

        public ViewResult FindGraduatesByYearHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(BLL.LoginAction resultOfLogin)
        {

                switch (resultOfLogin.AuthenticationCheck(manager))
                {
                    case AuthenticationStatus.Graduate:
                        return Redirect(@"HomePage");
                        break;
                    case AuthenticationStatus.Lecturer:
                        return Redirect(@"HomePage");
                        break;
                    case AuthenticationStatus.Administrator:
                        return Redirect(@"HomePage");
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
        public ActionResult Register(BLL.RegistrationAction registration)
        {
            try
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
            catch (Exception exc)
            {
                return Redirect(@"Register");
            }
        }

        [HttpPost]
        public ActionResult Changed(string Year)
        {
            int yearId = Convert.ToInt32(Year);
            return Json(manager.GetAllUsersByGraduateYear(yearId), JsonRequestBehavior.AllowGet);
        }

    }
}
