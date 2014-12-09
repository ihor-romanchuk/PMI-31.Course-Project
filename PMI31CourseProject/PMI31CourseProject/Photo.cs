using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase
{
    public class Photo
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
