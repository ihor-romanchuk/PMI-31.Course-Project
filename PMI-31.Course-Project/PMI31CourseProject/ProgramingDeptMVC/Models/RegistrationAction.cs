using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMI31CourseProject;
using PMI31CourseProject.Repository;

namespace ProgramingDeptMVC.Models
{
    public class RegistrationAction
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Role role { get; set; }

        public RegistrationStatus RegistrationCheck(Course_ProjectEntities1 entities)
        {
            Repository<Graduate> graduates = new Repository<Graduate>(entities);
            Repository<Lecturer> lecturers = new Repository<Lecturer>(entities);
            Graduate enterinGraduate = graduates.GetById(username);
            Lecturer enteringLecturer = lecturers.GetById(username);
            if (enterinGraduate == null)
            {
                return RegistrationStatus.RegistratedGraduate;
            }
            if (enteringLecturer == null)
            {
                return RegistrationStatus.RegistratedLecturer;
            }
            else
            {
                return RegistrationStatus.Failed;
            }
        }
    }
}