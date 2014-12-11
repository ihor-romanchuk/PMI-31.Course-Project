using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase
{
    public class UserInfo
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="UserInfo"/> class.
        /// </summary>
        public UserInfo()
        {
            this.ContactInfo = new ContactInfo();
            this.GraduateInfo = new GraduateInfo();
            this.Teacher = new Teacher();
        }

        /// <summary>
        /// Gets or sets Id of UserInfo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Email of UserInfo.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Gender of UserInfo.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets BIO of UserInfo.
        /// </summary>
        public string BIO { get; set; }

        /// <summary>
        /// Gets or sets User for UserInfo.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets Photo for UserInfo.
        /// </summary>
        public virtual Photo Photo { get; set; }

        /// <summary>
        /// Gets or sets ContactInfo of UserInfo.
        /// </summary>
        public ContactInfo ContactInfo { get; set; }

        /// <summary>
        /// Gets or sets GraduateInfo of UserInfo.
        /// </summary>
        public GraduateInfo GraduateInfo { get; set; }

        /// <summary>
        /// Gets or sets Teacher of UserInfo.
        /// </summary>
        public Teacher Teacher { get; set; }
    }
}
