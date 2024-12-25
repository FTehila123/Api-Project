using chineseAction.Models;
using Microsoft.EntityFrameworkCore;

namespace chineseAction.Dal
{
    public class CustomerDal : ICustomerDal
    {
        private readonly ProjectDbContext _context;

        public CustomerDal(ProjectDbContext context)
        {
            _context = context;
        }
        public bool Add(Customer customer)
        {
            if (customer != null)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
