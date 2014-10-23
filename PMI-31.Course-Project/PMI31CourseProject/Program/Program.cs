using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMI31CourseProject.Repository;
using PMI31CourseProject;
using DAL;

namespace PMI31CourseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork<Admin> unit = new UnitOfWork<Admin>();
            ConnectRepository<Admin> con = unit.ContactRepository;
            Admin us = new Admin();
            us.login = "login5";
            us.password = "111111";
            con.Add(us);
            unit.Save();
            IEnumerable<Admin> ie = con.GetAll();
            foreach (Admin el in ie)
            {
                Console.WriteLine(el.login + " " + el.password);
            }
            Console.WriteLine("asda");
            Console.ReadKey();
        }
    }
}
