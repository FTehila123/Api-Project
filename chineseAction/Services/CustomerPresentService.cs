using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services.Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chineseAction.Services
{
    public class CustomerPresentService : ICustomerPresentService
    {
        private readonly ICustomerPresentDal _customerPresentDal;
        private readonly ILoggerService _logger;
        public CustomerPresentService(ICustomerPresentDal customerPresentDal, ILoggerService logger)
        {
            _customerPresentDal = customerPresentDal;
            _logger = logger;
        }

        public IEnumerable<PresentMask> Cart(int id)
        {
            try { 
            return _customerPresentDal.Cart(id);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get all the presents for customer{id},exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public IEnumerable<Customer> CustomerForPresent(int id)
        {
            try
            {
                return _customerPresentDal.CustomerForPresent(id);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get all the customers for present{id},exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public CustomerPresent Add(CustomerPresent newcp)
        {
            try
            {
                return _customerPresentDal.Add(newcp);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to add present{newcp.PresentId} to cart of {newcp.CustomerId},exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public void Update(int customer)
        {
            try
            {
                _customerPresentDal.Update(customer);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to buy the cart for customer{customer},exception{e.Message}", "logs.txt");      
            }
        }

        public void Delete(int present, int customer)
        {
            try
            {
                _customerPresentDal.Delete(present, customer);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to delete present {present} for customer {customer},exception{e.Message}", "logs.txt");          
            }
        }

    }
}
