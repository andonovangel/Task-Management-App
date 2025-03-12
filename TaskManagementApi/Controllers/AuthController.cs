using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApi.Entities;
using TaskManagementApi.DTOs.User;
using TaskManagementApi.DTOs.Token;
using TaskManagementApi.DTOs.Auth;

namespace TaskManagementApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User created");
                    } 
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        //[HttpPost("login")]
        //public async Task<ActionResult<TokenResponseDTO>> Login(UserDTO request)
        //{
        //    var result = await _authService.LoginAsync(request);
        //    if (result is null)
        //    {
        //        return BadRequest("Invalid username or password.");
        //    }

        //    return Ok(result);
        //}

        //[HttpPost("refresh-token")]
        //public async Task<ActionResult<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO request)
        //{
        //    var result = await _authService.RefreshTokensAsync(request);
        //    if (result is null || result.AccessToken is null || result.RefreshToken is null)
        //    {
        //        return Unauthorized("Invalid refresh token.");
        //    }

        //    return Ok(result);
        //}

        //[Authorize]
        //[HttpGet]
        //public IActionResult AuthenticatedOnlyEndpoint()
        //{
        //    return Ok("You are authenticated");
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpGet("admin-only")]
        //public IActionResult AdminOnlyOnlyEndpoint()
        //{
        //    return Ok("You are an admin");
        //}
    }
}
