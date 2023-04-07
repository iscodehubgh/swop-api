//using DAL.CustomModel.Auth;
//using DAL.Models;
using DAL.CustomModel.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.Models;
using Services.Interfaces.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using WebAPI.Models.Auth;
//using WebAPI.Models.Auth;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //public class AuthController : BaseController<AuthController>
    public class AuthController : ControllerBase
    {
        private readonly swopContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(swopContext context,
                              UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromServices] IAuthService authService, [FromBody] UserRegistrationModel user)
        {
            var messages = new List<string>();
            var applicationUser = new ApplicationUser()
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, user.Password);

                if (result.Succeeded)
                {
                    return Ok(result);
                }

                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        messages.Add(error.Description);
                    }
                }

                return BadRequest(new { message = messages });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error " + ex });
                throw ex;
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromServices] IAuthService authService, [FromBody] LoginModel loginModel)
        {
            //var user = await _userManager.FindByNameAsync(data.UserName);
            //if (user == null)
            //{
            //    return new ResponseViewModel<object>
            //    {
            //        Status = false,
            //        Message = "Invalid UserName",
            //    };
            //}
            //var result = _signInManager.PasswordSignInAsync(user, user.PasswordHash, false, false);
            //if (result.IsCompleted == false)
            //{
            //    return new ResponseViewModel<object>
            //    {
            //        Status = false,
            //        Message = "Wrong Password",
            //    };
            //}

            var messages = new List<string>();

            try
            {
                var existingUser = await _userManager.FindByEmailAsync(loginModel.Email);

                if (existingUser != null && await _userManager.CheckPasswordAsync(existingUser, loginModel.Password))
                {
                    var signInResult = _signInManager.PasswordSignInAsync(existingUser, existingUser.PasswordHash, false, false);
                    var userRoles = await _userManager.GetRolesAsync(existingUser);

                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, existingUser.UserName),
                        new Claim(ClaimTypes.GivenName, existingUser.FirstName),
                        new Claim(ClaimTypes.Surname, existingUser.LastName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Secret")));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(issuer: _configuration.GetValue<string>("JWT:ValidIssuer"),
                                                            audience: _configuration.GetValue<string>("JWT:ValidAudience"),
                                                            claims: authClaims,
                                                            expires: DateTime.Now.AddMinutes(_configuration.GetValue<int>("JWT:ExpireInMinutes")),
                                                            signingCredentials: signinCredentials);
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    var tokres = await _userManager.SetAuthenticationTokenAsync(await _userManager.FindByNameAsync(existingUser.UserName), "JWT", "JWT Token", tokenString);

                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return NotFound(new { ErrorMessage = "Incorrect username or password" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = "Internam server error " + ex });
            }
        }

        [Authorize]
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser([FromServices] IAuthService authService, string id)
        {
            var messages = new List<string>();

            try
            {
                var existingUser = await _userManager.FindByIdAsync(id);

                if (existingUser != null)
                {
                    return Ok(existingUser);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error " + ex });
            }
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout([FromServices] IAuthService authService, [FromQuery] string email)
        {
            var messages = new List<string>();

            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                await _userManager.UpdateSecurityStampAsync(user);
                await _userManager.RemoveAuthenticationTokenAsync(user, "JWT", "JWT Token");

                await _signInManager.SignOutAsync();
                //Response.Headers.Remove("Authorization");

                return Ok(new { Message = "User logged out" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error " + ex });
            }
        }
    }
}
