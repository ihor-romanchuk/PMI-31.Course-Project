using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase
{
    /// <summary>
    /// Initialize a new instance of the <see cref="Photo"/> class.
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Gets or sets Id value for Photo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Data value for Photo.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Gets or sets UserInfo value for Photo.
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }
    }
}
