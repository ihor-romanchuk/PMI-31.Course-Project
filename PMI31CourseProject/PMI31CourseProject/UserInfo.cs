using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase
{
    public class UserInfo
    {
        public UserInfo()
        {
            this.ContactInfo = new ContactInfo();
            this.GraduateInfo = new GraduateInfo();
            this.Teacher = new Teacher();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BIO { get; set; }


        public virtual User User { get; set; }

        public virtual Photo Photo { get; set; }

        public ContactInfo ContactInfo { get; set; }
        public GraduateInfo GraduateInfo { get; set; }
        public Teacher Teacher { get; set; }
    }
}
