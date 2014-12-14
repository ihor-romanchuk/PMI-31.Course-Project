using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
     /// <summary>
    /// enum Registration Status users
    /// </summary>
    public enum RegistrationStatus
    {
        RegistratedGraduate, RegistratedLecturer, Failed, FullNameRegistred, LoginRegistread, NonFullName
    }

     /// <summary>
    /// enum Role users
    /// </summary>
    public enum Role
    {
        Graduate, Lecturer
    }
}
