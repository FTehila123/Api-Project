using chineseAction.Models;
using chineseAction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly JwtTokenService _jwtTokenService;
        private readonly ProjectDbContext _context;
        private readonly PasswordHasher<Customer> _passwordHasher;

        public AuthController(JwtTokenService jwtTokenService, ProjectDbContext context)
            {
                _jwtTokenService = jwtTokenService;
                _context = context;
                _passwordHasher = new PasswordHasher<Customer>();
        }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequest request)
            {

            List<Maneger> m = _context.Manegers.ToList();
            Maneger maneger = m.Find(x => x.UserName == request.Username);
            if (maneger!=null)
            {
                if (maneger.Password == request.Password)
                {
                    var roles = new List<string> { "Admin" };
                    var token = _jwtTokenService.GenerateJwtToken(request.Username,maneger.Id, roles);

                    return Ok(new { Token = token ,IsManager=true});
                }
                else return Unauthorized("password is not currect");
            }
            else
            {
                List<Customer> c = _context.Customers.ToList();
               Customer customer = c.Find(x => x.UserName == request.Username);
                if (customer!=null)
                {
                    if (_passwordHasher.VerifyHashedPassword(customer, customer.Password, request.Password) == PasswordVerificationResult.Success)
                    {
                        var roles = new List<string> { "User" };
                        var token = _jwtTokenService.GenerateJwtToken(request.Username,customer.Id, roles);

                        return Ok(new { Token = token, IsManager = false });
                    }
                    else return Unauthorized("password is not currect");
                }
            }
            return Unauthorized("go to register");
            }
        }
}
