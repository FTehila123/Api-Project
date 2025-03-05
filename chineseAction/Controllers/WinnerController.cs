using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnerController : ControllerBase
    {
        private readonly IWinnerService _winnerService;

        public WinnerController(IWinnerService winnerService)
        {
            _winnerService = winnerService;  
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IEnumerable<WinnerMask> GetWinners()
        {
            return _winnerService.GetWinners();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("{p}")]
        public ActionResult<Customer> Lottery(int p)
        {
            Customer good = _winnerService.Lottery(p);
            if (good != null)
                return Ok(good);
            return BadRequest("not exists");
        }
      
    }
}
