using chineseAction.Models;

namespace chineseAction.Dal
{
    public interface ICustomerDal
    {
        bool Add(Customer customer);
        public List<Customer> GetCustomers();
    }
}