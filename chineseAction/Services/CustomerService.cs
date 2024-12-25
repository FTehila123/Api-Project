using chineseAction.Dal;
using chineseAction.Models;

namespace chineseAction.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public bool Add(Customer c)
        {
            List<Customer> customers = _customerDal.GetCustomers();
            bool check = customers.Exists(x => x.Mail == c.Mail || x.UserName==c.UserName);
            if (check==true)
            {
                return false;
            }
            return _customerDal.Add(c);
        }
    }
}
