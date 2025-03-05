using chineseAction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace chineseAction.Dal
{
    public class CustomerDal : ICustomerDal
    {


        private readonly PasswordHasher<Customer> _passwordHasher;
        private readonly ProjectDbContext _context;

        public CustomerDal(ProjectDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Customer>();
        }
        public bool Add(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    customer.Password = _passwordHasher.HashPassword(customer, customer.Password);
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    return true;
                }
                throw new KeyNotFoundException("somthing went worn, try register again");
            }
            catch(KeyNotFoundException ex)
            { 
                return false;
                throw ex;
               
            }
            

        }
        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
