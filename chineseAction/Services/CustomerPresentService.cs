using chineseAction.Dal;
using chineseAction.Models;

namespace chineseAction.Services
{
    public class CustomerPresentService : ICustomerPresentService
    {
        private readonly ICustomerPresentDal _customerPresentDal;
        public CustomerPresentService(ICustomerPresentDal customerPresentDal)
        {
            _customerPresentDal = customerPresentDal;
        }
        //public IEnumerable<CustomerPresentMask> GetPresent()
        //{
        //    return _customerPresentDal.GetPresent();
        //}
    }
}
