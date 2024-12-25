using chineseAction.Models;
using chineseAction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly JwtTokenService _jwtTokenService;
        private readonly ProjectDbContext _context;

        public AuthController(JwtTokenService jwtTokenService, ProjectDbContext context)
            {
                _jwtTokenService = jwtTokenService;
                _context = context;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequest request)
            {

            List<Maneger> m = _context.Manegers.ToList();
            List<Maneger>? maneger = m.Where(x => x.UserName == request.Username).ToList();
            if (maneger.Count>0)
            {
                if (maneger[0].Password == request.Password)
                {
                    var roles = new List<string> { "Admin" };
                    var token = _jwtTokenService.GenerateJwtToken(request.Username, roles);

                    return Ok(new { Token = token });
                }
                else return Unauthorized("password is not currect");
            }
            else
            {
                List<Customer> c = _context.Customers.ToList();
                List<Customer>? customer = c.Where(x => x.UserName == request.Username).ToList();
                if (customer.Count > 0)
                {
                    if (customer[0].Password == request.Password)
                    {
                        var roles = new List<string> { "User" };
                        var token = _jwtTokenService.GenerateJwtToken(request.Username, roles);

                        return Ok(new { Token = token });
                    }
                    else return Unauthorized("password is not currect");
                }
            }
            return Unauthorized("go to register");
            }
        }
}
