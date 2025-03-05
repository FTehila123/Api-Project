using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPresentController : ControllerBase
    {
        private readonly ICustomerPresentService _customerPresentService;
        private readonly JwtTokenService _jwtTokenService;

        public CustomerPresentController(ICustomerPresentService customerPresentService, JwtTokenService jwtTokenService)
        {
            _customerPresentService = customerPresentService;
            _jwtTokenService = jwtTokenService;
        }

        [Authorize(Roles = "User")]
        [HttpGet("cart")]
        public IEnumerable<PresentMask> Cart()
        {
            var token = HttpContext.GetTokenAsync("access_token");
            var userId = _jwtTokenService.ExtractUserIdFromToken(token.Result);
            var cpresent = _customerPresentService.Cart(Int32.Parse(userId));
            return cpresent;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("customerForPresent{id}")]
        public ActionResult<IEnumerable<PresentMask>> CustomerForPresent(int id)
        {
            var cpresent = _customerPresentService.CustomerForPresent(id);
            return Ok(cpresent);
        }

        [Authorize(Roles = "User")]
        [HttpPost("{p}")]
        public ActionResult<PresentMask> Create(int p)
        {
            var token =  HttpContext.GetTokenAsync("access_token");
            var userId = _jwtTokenService.ExtractUserIdFromToken(token.Result);
            CustomerPresent newcp = new CustomerPresent();
            newcp.CustomerId = Int32.Parse(userId);
            newcp.PresentId = p;
            newcp.Status = false;
            CustomerPresent good = _customerPresentService.Add(newcp);
            if (good != null)
                return Ok(good);
            return BadRequest("not exists");
        }

        [Authorize(Roles = "User")]
        [HttpPut]
        public IActionResult Update()
        {
            var token = HttpContext.GetTokenAsync("access_token");
            var userId = _jwtTokenService.ExtractUserIdFromToken(token.Result);
            _customerPresentService.Update(Int32.Parse(userId));
            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpDelete("{p}")]
        public IActionResult Delete(int p)
        {
            var token = HttpContext.GetTokenAsync("access_token");
            var userId = _jwtTokenService.ExtractUserIdFromToken(token.Result);
            _customerPresentService.Delete(p, Int32.Parse(userId));
            return Ok();
        }
    }
}
