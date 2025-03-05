using chineseAction.Models;
using chineseAction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentsController : ControllerBase
    {
        private readonly IPresentService _presentService;
        private readonly ICustomerPresentService _customerPresentService;

        public PresentsController(IPresentService presentService, ICustomerPresentService customerPresentService)
        {
            _presentService = presentService;
            _customerPresentService = customerPresentService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PresentMask>> GetTasks()
        {
            var tasks = _presentService.GetPresent();
            return tasks;
        }

        // get : api/Tasks/{id}
        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}")]
        public ActionResult<PresentMask> GetById(int id)
        {
            var presents = _presentService.GetById(id);
            return presents;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("byMany")]
        public IActionResult deleteManyPresent([FromQuery] List<int> list)
        {
            _presentService.DeleteManyPresent(list);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<PresentMask> Create(PresentMask presentCreat)
        {
            PresentMask good = _presentService.Add(presentCreat);
            if (good != null)
                return Ok(good);
            return BadRequest("not exists");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(PresentMask p)
        {
            _presentService.Update(p.Id, p.Name, p.Description, p.Category, p.NumBuyers, p.Image, p.Price, p.Donater);
            return Ok();
        }
   

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _presentService.Delete(id);

            return Ok();
        }


        //[HttpGet("byNum/{numBuyers}")]
        //public ActionResult<IEnumerable<Present>> GetByBuyers(int numBuyers)
        //{
        //    var present = _presentService.GetByBuyers(numBuyers);
        //    return present;
        //}

        [HttpGet("byName/{name}")]
        public ActionResult<IEnumerable<Present>> GetByName(string name)
        {
            var present = _presentService.GetByName(name);
            return present;
        }

        [HttpGet("byDonater{id}")]
        public ActionResult<IEnumerable<PresentMask>> GetByDonaterId( int id)
        {
           var presents= _presentService.GetByDonaterId(id);

            return presents;
        }

        [HttpGet("mostExpensive")]
        public ActionResult<PresentMask> GetByMostExpensive()
        {
            var presents = _presentService.GetByMostExpensive();
            return presents;
        }

        [HttpGet("mostPopular")]
        public ActionResult<PresentMask> mostPopular()
        {
            var presents = _presentService.GetByPopular();
            return presents;
        }

        [HttpGet("OrderByPrice")]
        public ActionResult<List<PresentMask>> OrderByPrice()
        {
            var presents = _presentService.GetByPrice();
            return presents;
        }

        [HttpGet("orderByCategory")]
        public ActionResult<List<PresentMask>> orderByCategory()
        {
            var presents = _presentService.OrderByCategory();
            return presents;
        }


    }
}
