using AuthenticationAndAuthorization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAndAuthorization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (IsValidUser(model.Username,model.Password))
            {
                var token = GenerateJwtToken(model.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
        private bool IsValidUser(string username, string password)
        {
            
            return (username == "testuser" && password == "password123");
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username) 
            };

           

            if (username == "testuser")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin")); 
            }

            var key = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsAVeryStrongAndSecretKeyForYourJwtTokenGenerationThatShouldBeAtLeast32BytesLongAndRandomandthisisnot32bitslong"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "MyAuthServer",
                audience: "MyApiUsers",
                claims: claims, 
                expires: DateTime.UtcNow.AddMinutes(2), 
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
