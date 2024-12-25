using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPresentController : ControllerBase
    {
        private readonly ICustomerPresentService _customerPresentService;

        public CustomerPresentController(ICustomerPresentService customerPresentService)
        {
            _customerPresentService = customerPresentService;
        }
        //[HttpGet]
        //public IEnumerable<CustomerPresentMask> GetTasks()
        //{
        //    var cpresent = _customerPresentService.GetPresent();
        //    return cpresent;
        //}
    }
}
