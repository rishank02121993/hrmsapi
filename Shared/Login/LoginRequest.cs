using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Login
{
    public class LoginRequest
    {
        /// <summary>
        /// The username or email address of the user trying to log in.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}
