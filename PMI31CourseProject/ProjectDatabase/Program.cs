using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connect = new Course_ProjectEntities())
            {
                var result = from i in connect.UserContext
                             where i.FullName == "Тимощук Андрій Миколайовч"
                             select new { Name = i.FullName, Spec = i.UserInfo.GraduateInfo.Speciality, EYear = i.UserInfo.GraduateInfo.EntranceYear, GYear = i.UserInfo.GraduateInfo.GraduationYear };

                foreach (var i in result)
                {
                    Console.WriteLine(i.Name + " " + i.Spec + " " + i.EYear + " " + i.GYear);
                }
            }


            Console.ReadKey();
        }
    }
}