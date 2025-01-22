using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.JWT;
using Shared.Login;
using System.Security.Claims;

namespace hrmsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // POST api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid login request.");
            }

            // Validate user credentials (this could be a database check, etc.)
            if (ValidateCredentials(loginRequest.Username, loginRequest.Password))
            {
                // Create a list of claims based on the user data
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginRequest.Username),
                    new Claim(ClaimTypes.Role, "User") // Add any other claims here (e.g., roles, permissions)
                };

                // Generate JWT token
                var jwtTokenModel = _tokenService.GenerateToken(claims);

                // Return the JWT token to the client
                return Ok(jwtTokenModel);
            }

            return Unauthorized("Invalid username or password.");
        }

        // Example endpoint for refreshing a JWT token using a refresh token (optional)
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            if (string.IsNullOrEmpty(refreshTokenRequest.RefreshToken))
            {
                return BadRequest("Refresh token is required.");
            }

            // Validate the refresh token (you could implement your refresh token logic here)
            if (ValidateRefreshToken(refreshTokenRequest.RefreshToken))
            {
                // You could return a new access token here if the refresh token is valid
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "SomeUser") // Add the proper claims for the user
                };

                var jwtTokenModel = _tokenService.GenerateToken(claims);

                return Ok(jwtTokenModel);
            }

            return Unauthorized("Invalid refresh token.");
        }

        // Dummy validation function for login
        private bool ValidateCredentials(string username, string password)
        {
            // Implement your credential validation logic here, such as checking a database or an external service.
            return username == "admin" && password == "password"; // Example hardcoded credentials
        }

        // Dummy refresh token validation function (implement actual logic as needed)
        private bool ValidateRefreshToken(string refreshToken)
        {
            // Implement your refresh token validation logic here (e.g., check against a store or database)
            return refreshToken == "valid-refresh-token"; // Example refresh token validation
        }
    }
}
