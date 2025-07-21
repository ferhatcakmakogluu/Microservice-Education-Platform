using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.IdentityServer.Dtos;
using OnlineCourse.IdentityServer.Models;
using OnlineCourse.Shared.Dtos;

namespace OnlineCourse.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUp)
        {
            var user = new ApplicationUser
            {
                UserName = signUp.UserName,
                Email = signUp.Email,
                City = signUp.City
            };

            var result = await _userManager.CreateAsync(user,signUp.Password);

            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 404));
            }

            return NoContent();
        }
    }
}
