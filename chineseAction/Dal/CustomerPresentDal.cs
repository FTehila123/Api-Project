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


        public IEnumerable<PresentMask> Cart(int id)
        {

            var present = from cp in _context.CustomerPresents.Where(x => x.CustomerId == id && x.Status == false)
                          join p in _context.Presents on cp.PresentId equals p.Id 
                          join c in _context.Categorys on p.CategoryId equals c.Id
                          join d in _context.Donaters on p.DonaterId equals d.Id
                         
                          

                          select new PresentMask
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Description = p.Description,
                              Category = c.Name,
                              Price = p.Price,
                              Image = p.Image,
                              Donater = d.FullName,
                              NumBuyers = p.NumBuyers
                          };
            if (present != null)
            {
                _context.SaveChanges();
                return (present);
            }
            return null;
        }

        public IEnumerable<Customer> CustomerForPresent(int id)
        {
            var customer = from cp in _context.CustomerPresents.Where(x => x.PresentId == id && x.Status == true)
                          join c in _context.Customers on cp.CustomerId equals c.Id

                          select new Customer
                          {
                              Id = c.Id,
                              FullName = c.FullName,
                              UserName = c.UserName,
                              Password = c.Password,
                              Phone = c.Phone,
                              Mail = c.Mail,             
                          };
            if (customer != null)
            {
                _context.SaveChanges();
                return (customer);
            }
            return null;
        }

        public CustomerPresent Add(CustomerPresent newcp)
        {
            if (newcp != null)
            {
                newcp.Id = 0;
                _context.CustomerPresents.Add(newcp);
                _context.SaveChanges();
                return newcp;
            }
            return null;
        }

        public void Delete(int present ,int customer)
        {
            CustomerPresent? cp = _context.CustomerPresents.First(x=>x.PresentId==present && x.CustomerId==customer && x.Status == false);

            if (cp != null)
            {
                _context.CustomerPresents.Remove(cp);
                _context.SaveChanges();
            }
        }
        public void Update(int customer)
        {        
            List<CustomerPresent> cp = _context.CustomerPresents.Where(x=> x.CustomerId == customer).ToList();
             cp.ForEach(c=>c.Status=true);
             cp.ForEach(c => _context.CustomerPresents.Update(c));
                _context.SaveChanges();
 
        }



    }
}
