using chineseAction.Models;

namespace chineseAction.Services
{
    public interface ICustomerPresentService
    {
        public IEnumerable<PresentMask> Cart(int id);
        public IEnumerable<Customer> CustomerForPresent(int id);
        public CustomerPresent Add(CustomerPresent newcp);
        public void Update(int customer);
        public void Delete(int present,int customer);
    }
}