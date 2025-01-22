using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JWT
{
    public class JwtTokenModel
    {
        /// <summary>
        /// The generated JWT access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The refresh token used to obtain a new access token when the current one expires.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// The date and time when the token expires (in UTC).
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}
