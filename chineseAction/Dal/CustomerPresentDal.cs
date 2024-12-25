using chineseAction.Models;
using Microsoft.EntityFrameworkCore;

namespace chineseAction.Dal
{
    public class CustomerPresentDal : ICustomerPresentDal
    {
        private readonly ProjectDbContext _context;
        public CustomerPresentDal(ProjectDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomerPresentMask> GetPresent()
        {
            var PresentWithCustomer = from p in _context.Presents
                                      join cp in _context.CustomerPresents on p.Id equals cp.PresentId
                                      join c in _context.Customers on cp.CustomerId equals c.Id
                                      select new CustomerPresentMask
                                      {
                                          PresentName = p.Name,
                                          customers = _context.CustomerPresents.Where(x => x.PresentId == p.Id && x.Status == true).Select(x => new Customer
                                          {
                                            Id=c.Id,
                                            FullName=c.FullName,
                                            Mail=c.Mail,
                                            Password=c.Password,
                                            UserName=c.UserName,
                                            Phone=c.Phone
                                          }).ToList()
                                      };
            var x = PresentWithCustomer.ToList();
            return x.DistinctBy(p => p.PresentName);
        }

        //public IEnumerable<Customer> GetCustomersByPresent(int presentId)
        //{
        //    var customers = _context.CustomerPresents.Where(x => x.PresentId == presentId).Include(c => c.Customer).Select(x => new Customer
        //    {
        //        FullName=x.

        //    }).ToList();

        //}




    }
}
