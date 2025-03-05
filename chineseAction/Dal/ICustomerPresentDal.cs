using chineseAction.Models;

namespace chineseAction.Dal
{
    public interface ICustomerPresentDal
    {
        public IEnumerable<PresentMask> Cart(int id);
        public IEnumerable<Customer> CustomerForPresent(int id);
        public CustomerPresent Add(CustomerPresent newcp);
        public void Delete(int present, int customer);
        public void Update(int customer);
    }
}