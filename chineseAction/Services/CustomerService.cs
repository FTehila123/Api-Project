using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services.Logger;

namespace chineseAction.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILoggerService _logger;
        private readonly ICustomerDal _customerDal;
        public CustomerService(ICustomerDal customerDal, ILoggerService logger)
        {
            _customerDal = customerDal;
            _logger = logger;
        }


        public bool Add(Customer c)
        {
            try
            {
                List<Customer> customers = _customerDal.GetCustomers();
                bool check = customers.Exists(x => x.Mail == c.Mail || x.UserName == c.UserName);
                if (check == true)
                {
                    return false;
                }
                return _customerDal.Add(c);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to add the customer {c.Id},exception{e.Message}", "logs.txt");
                return false;
            }
        }
    }
}
