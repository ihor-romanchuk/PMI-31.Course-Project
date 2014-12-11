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
using User = ProjectDatabase.User;

namespace ProgramingDeptMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ManageUsers manager = new ManageUsers();
        private string signInMassage = string.Empty;
        public ViewResult SignIn()
        {
            ViewBag.Title = "Головна";
            @ViewBag.Massage = this.signInMassage;
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
        public ActionResult SignIn(Models.LoginUser userLoginData)
        {
            BLL.LoginAction resultOfLogin = new LoginAction(){UserLogin = userLoginData.Username, UserPassword = userLoginData.Password};
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
                   this.signInMassage = "Немає користувача";
                    return Redirect("SignIn");
                    break;
                case AuthenticationStatus.WrongPassword:
                    this.signInMassage = "Невірний пароль";
                    return Redirect("SignIn");
                    break;
                default:
                    this.signInMassage = "Помилка реєстрації";
                    return Redirect("SignIn");

            }
        }

        [HttpPost]
        public ActionResult Register(RegisterUser user)
        {
            BLL.RegistrationAction registration = new RegistrationAction(){email = user.Email, fullName = user.FullName, password = user.Password, username = user.Login};
                switch (registration.RegistrationCheck(manager))
                {
                    case RegistrationStatus.RegistratedGraduate:
                        return Redirect(@"HomePage");
                        break;
                    case RegistrationStatus.RegistratedLecturer:
                        return Redirect(@"HomePage");
                        break;
                    case RegistrationStatus.Failed:
                        return Redirect(@"Register");
                        break;
                    default:
                        return Redirect(@"Register");
                }
            
        }

        [HttpPost]
        public ActionResult Changed(string Year)
        {
            if (Year == "undefined")
            {
                Year = "0";
            }
            int yearId = Convert.ToInt32(Year);
            List<ProjectDatabase.User> usersFromDb = manager.GetAllUsersByGraduateYear(yearId);
            List<Models.User> users = new List<Models.User>();
            foreach (User user in usersFromDb)
            {
                users.Add(new Models.User() { FullName = user.FullName });
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

    }
}
