using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JWT
{
    public class RefreshTokenRequest
    {
        /// <summary>
        /// The refresh token provided to the user upon login.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
