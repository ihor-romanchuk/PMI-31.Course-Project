using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase
{
    /// <summary>
    /// Initialize a new instance of the <see cref="User"/> class.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets Id of user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Login of user.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets Role of user.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets FullName of user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets IsRegistered of user.
        /// </summary>
        public bool IsRegistered { get; set; }

        /// <summary>
        /// Gets or sets Password of user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets UserInfo of user.
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }
    }
}
