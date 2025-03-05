using chineseAction.Models;
using chineseAction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chineseAction.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
            private readonly ICustomerService _customerService;

            public CustomerController(ICustomerService customerService)
            {
            _customerService = customerService;
            }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Customer customer)
        {
            bool good = _customerService.Add(customer);
            if (good)
                return Ok(customer);
            return BadRequest("customer exists");
        }

    }
}
