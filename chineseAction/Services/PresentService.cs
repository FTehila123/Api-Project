using chineseAction.Dal;
using chineseAction.Models;

namespace chineseAction.Services
{
    public class PresentService: IPresentService
    {
        private readonly IPresentDal _presentDal;
        public PresentService(IPresentDal presentDal)
        {
            _presentDal = presentDal;
        }
        public bool Add(Present newPresent)
        {
            return _presentDal.Add(newPresent);
        }

        //public List<Present> GetTasks(string status1)
        //{
        //    var tasks = _presentDal.GetTasks();
        //    List<Present> task = tasks.Where(x => x.Status.Contains(status1)).ToList();
        //    if (task == null)
        //        return new List<Present>();
        //    return task;
        //}

        public void Update(int Id, string Name, string Description, int? CategoryId, int? NumBuyers, string? Image, int Price, int DonaterId)
        {
            Present newPresent = new Present();
            newPresent.Name = Name;
            newPresent.Description = Description;
            newPresent.CategoryId = CategoryId;
            newPresent.NumBuyers = NumBuyers;
            newPresent.Image = Image;
            newPresent.Price = Price;
            newPresent.DonaterId = DonaterId;
            _presentDal.Update(Id, newPresent);
        }

        public List<Present> Delete(int id)
        {
            _presentDal.Delete(id);
            return new List<Present>();
        }

        public List<PresentMask> GetPresent()
        {
            var presents = _presentDal.GetPresent();
            return presents;
        }

        public PresentMask GetById(int id)
        {
            var presents = _presentDal.GetById(id);
            return presents;
        }
        public List<Present> GetByBuyers(int num)
        {
            var presents = _presentDal.GetByBuyers(num);
            return presents;
        }

        public List<Present> GetByName(string name)
        {
            var presents = _presentDal.GetByName(name);
            return presents;
        }

        public List<Present> GetByDonaterId(int id)
        {
            var presents = _presentDal.GetByDonaterId(id);
            return presents;
        }

        public PresentMask GetByMostExpensive()
        {
            var presents = _presentDal.GetPresent();
            var p = presents.OrderByDescending(x => x.Price).First();
            return p;
        }

        public PresentMask GetByPopular()
        {
            var presents = _presentDal.GetPresent();
            var p = presents.OrderByDescending(x => x.NumBuyers).First();
            return p;
        }

        public List<PresentMask> GetByPrice()
        {
            var presents = _presentDal.GetPresent();
            var p = presents.OrderBy(x => x.Price).ToList();
            return p;
        }
        public List<PresentMask> OrderByCategory()
        {
            var presents = _presentDal.GetPresent();
            var p = presents.OrderBy(x => x.Category).ToList();
            return p;
        }
    }
}
