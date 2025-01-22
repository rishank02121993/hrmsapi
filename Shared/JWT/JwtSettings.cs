using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JWT
{
    public class JwtSettings
    {
        /// <summary>
        /// The issuer of the JWT token, typically the application itself.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// The intended recipient of the token, often the same as the issuer.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// The secret key used to sign the JWT token.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// The duration (in minutes) for which the token is valid.
        /// </summary>
        public int ExpirationMinutes { get; set; }
    }

}
