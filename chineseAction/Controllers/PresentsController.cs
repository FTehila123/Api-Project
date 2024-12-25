using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chineseAction.Models;
using chineseAction.Services;
using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Authorization;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentsController : ControllerBase
    {
        private readonly IPresentService _presentService;

        public PresentsController(IPresentService presentService)
        {
            _presentService = presentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PresentMask>> GetTasks()
        {
            var tasks = _presentService.GetPresent();
            return tasks;
        }

        // get : api/Tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<PresentMask> GetById(int id)
        {
            var presents = _presentService.GetById(id);
            return presents;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Present> Create(Present presentCreat)
        {
            bool good = _presentService.Add(presentCreat);
            if (good)
                return Ok("new present created");
            return BadRequest("not exists");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromQuery] int Id, string Name, string Description, int? CategoryId, int? NumBuyers, string? Image, int Price, int DonaterId)
        {
            _presentService.Update(Id, Name, Description, CategoryId, NumBuyers, Image, Price, DonaterId);
            return Ok();
        }

        //post : api/Tasks/{id
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult<Present> Delete(int id)
        {
            _presentService.Delete(id);

            return Ok();
        }

        [HttpGet("byNum/{numBuyers}")]
        public ActionResult<IEnumerable<Present>> GetByBuyers(int numBuyers)
        {
            var present = _presentService.GetByBuyers(numBuyers);
            return present;
        }

        [HttpGet("byName/{name}")]
        public ActionResult<IEnumerable<Present>> GetByName(string name)
        {
            var present = _presentService.GetByName(name);
            return present;
        }

        [HttpGet("byDonater/{donaterId}")]
        public ActionResult<IEnumerable<Present>> GetByDonaterId(int donaterId)
        {
           var presents= _presentService.GetByDonaterId(donaterId);

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
