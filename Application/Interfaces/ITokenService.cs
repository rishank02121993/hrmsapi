using Shared.JWT;
using System.Security.Claims;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Generates a JWT access token based on the provided claims.
        /// </summary>
        /// <param name="claims">A collection of claims to include in the token.</param>
        /// <returns>A model containing the access token, refresh token, and expiration details.</returns>
        JwtTokenModel GenerateToken(IEnumerable<Claim> claims);

        /// <summary>
        /// Validates the given JWT token and returns the claims if valid.
        /// </summary>
        /// <param name="token">The JWT token to validate.</param>
        /// <returns>The claims from the token if validation succeeds; otherwise, null.</returns>
        IEnumerable<Claim> ValidateToken(string token);

        /// <summary>
        /// Generates a new refresh token.
        /// </summary>
        /// <returns>A secure, random refresh token string.</returns>
        string GenerateRefreshToken();
    }
}
