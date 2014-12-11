using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BLL;
using PMI31CourseProject;
using PMI31CourseProject.Repository;

namespace ProgramingDeptMVC.Models
{
    public class RegisterUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}