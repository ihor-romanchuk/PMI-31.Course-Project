using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase
{
    /// <summary>
    /// Initialize a new instance of the <see cref="GraduateInfo"/> class.
    /// </summary>
    public class GraduateInfo
    {
        /// <summary>
        /// Gets or sets University value for GraduateInfo.
        /// </summary>
        public string University { get; set; }

        /// <summary>
        /// Gets or sets Speciality value for GraduateInfo.
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// Gets or sets EntranceYear value for GraduateInfo.
        /// </summary>
        public int EntranceYear { get; set; }

        /// <summary>
        /// Gets or sets GraduationYear value for GraduateInfo.
        /// </summary>
        public int GraduationYear { get; set; }
    }
}
