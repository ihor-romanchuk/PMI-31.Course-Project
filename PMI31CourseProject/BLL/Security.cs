using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     /// <summary>
    /// class Security
    /// </summary>
    public class Security
    {
        /// <summary>
        /// This method  Hash Password 
        /// </summary>
        /// <param name="password">Password to hash.</param>
        /// <returns>Handled password.</returns>
        public static string HashPassword(string password)
        {
            if (password.Equals(string.Empty))
            {
                return password;
            }
            SHA256CryptoServiceProvider SHA = new SHA256CryptoServiceProvider();
            byte[] byteFromPassword = Encoding.Unicode.GetBytes(password);
            byte[] hashingPassword = SHA.ComputeHash(byteFromPassword);
            string code = "";

            for (int i = 0; i < 16; i++)
            {
                code += string.Format("{0:x2}", hashingPassword[i]);
            }
            return code;
        }
    }
}
