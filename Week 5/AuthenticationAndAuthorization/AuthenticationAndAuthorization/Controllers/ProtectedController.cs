using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        [HttpGet("data")]
        [Authorize] 
        public IActionResult GetProtectedData()
        {
            var username = User.Identity?.Name; 

            return Ok($"Hello, {username}! You have accessed protected data.");
        }
        [HttpGet("admin-only")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminOnlyData()
        {
            var adminUsername = User.Identity?.Name;
            return Ok($"Welcome, {adminUsername}! This is highly confidential data accessible only by Admins.");
        }


    }
}
