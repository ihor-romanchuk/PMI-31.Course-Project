using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public bool IsRegistered { get; set; }
        public string Password { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
