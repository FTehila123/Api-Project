using chineseAction.Models;
using chineseAction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chineseAction.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DonaterController : ControllerBase
    {
        private readonly IDonaterService _donaterService;

        public DonaterController(IDonaterService donaterService)
        {
            _donaterService = donaterService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Donater>> GetDonater()
        {
            var tasks = _donaterService.GetDonater();
            return tasks;
        }

        [HttpPost]
        public ActionResult<Donater> Create(Donater donaterCreat)
        {
            bool good = _donaterService.Add(donaterCreat);
            if (good)
                return Ok("new present created");
            return BadRequest("not exists");
        }

        //post : api/Tasks/{updateTask}
        [HttpPut]
        public IActionResult Update(Donater d)
        {
            _donaterService.Update(d);
            return Ok();
        }

        //post : api/Tasks/{id

        [HttpDelete("{id}")]
        public ActionResult<Donater> Delete(int id)
        {
            _donaterService.Delete(id);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Donater> GetById(int id)
        {
            var donater = _donaterService.GetById(id);
            return donater;
        }

        [HttpGet("byName/{name}")]
        public ActionResult<Donater> GetByName(string name)
        {
            var donater = _donaterService.GetByName(name);
            return donater;
        }

        [HttpGet("byMail/{mail}")]
        public ActionResult<IEnumerable<Donater>> GetByMail(string mail)
        {
            var donater = _donaterService.GetByMail(mail);
            return donater;
        }

        [HttpGet("byPresent/{Id}")]
        public ActionResult<Donater> GetByPresent(int Id)
        {
            var donater = _donaterService.GetByPresent(Id);
            return donater;
        }
    }
}
