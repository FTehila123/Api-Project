using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services.Logger;

namespace chineseAction.Services
{
    public class PresentService: IPresentService
    {
        private readonly IPresentDal _presentDal;
        private readonly ILoggerService _logger;
        private readonly ProjectDbContext _context;
        public PresentService(IPresentDal presentDal,ProjectDbContext context, ILoggerService logger)
        {
            _logger = logger;
            _presentDal = presentDal;
            _context = context;
        }
        public PresentMask Add(PresentMask newPresent)
        {
            try
            {
                _logger.Log($"Create present:{newPresent.Name}", "present.txt");
                return _presentDal.Add(newPresent);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to add present {newPresent.Id},exception{e.Message}", "logs.txt");
                return null;
            }

        }

        public void Update(int Id, string Name, string Description, string? CategoryId, int? NumBuyers, string? Image, int? Price, string DonaterId)
        {
            try
            {
                Category c = _context.Categorys.First(x => x.Name == CategoryId);
                Donater d = _context.Donaters.First(x => x.FullName == DonaterId);
                Present newPresent = new Present();
                newPresent.Id = Id;
                newPresent.Name = Name;
                newPresent.Description = Description;
                newPresent.CategoryId = c.Id;
                newPresent.NumBuyers = NumBuyers;
                newPresent.Image = Image;
                newPresent.Price = Price;
                newPresent.DonaterId = d.Id;
                _presentDal.Update(newPresent);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to update present {Id},exception{e.Message}", "logs.txt");
            }
        }

        public List<Present> Delete(int id)
        {
            try
            {
                _presentDal.Delete(id);
                return new List<Present>();
            }
            catch (Exception e)
            {
                _logger.Log($"failed to delete present {id},exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public void DeleteManyPresent(List<int> list)
        {
            try
            {
                foreach (var l in list)
                {
                    _presentDal.Delete(l);
                }
            }
            catch (Exception e)
            {
                _logger.Log($"failed to delete all the presents,exception{e.Message}", "logs.txt");
            }

        }

        public List<PresentMask> GetPresent()
        {
            try
            {
                var presents = _presentDal.GetPresent();
                return presents;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get all the winners,exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public PresentMask GetById(int id)
        {
            try
            {
                var presents = _presentDal.GetById(id);
                return presents;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get the present{id},exception{e.Message}", "logs.txt");
                return null;
            }
        }
        public List<Present> GetByBuyers(int num)
        {
            try
            {
                var presents = _presentDal.GetByBuyers(num);
                return presents;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get by buyers,exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public List<Present> GetByName(string name)
        {
            try
            {
                var presents = _presentDal.GetByName(name);
                return presents;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get the present {name},exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public List<PresentMask> GetByDonaterId(int id)
        {
            try
            {
                var presents = _presentDal.GetByDonaterId(id);
                return presents;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get by donater {id},exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public PresentMask GetByMostExpensive()
        {
            try
            {
                var presents = _presentDal.GetPresent();
                var p = presents.OrderByDescending(x => x.Price).First();
                return p;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get by most expensive,exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public PresentMask GetByPopular()
        {
            try
            {
                var presents = _presentDal.GetPresent();
                var p = presents.OrderByDescending(x => x.NumBuyers).First();
                return p;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get by popular,exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public List<PresentMask> GetByPrice()
        {
            try
            {
                var presents = _presentDal.GetPresent();
                var p = presents.OrderBy(x => x.Price).ToList();
                return p;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get by price,exception{e.Message}", "logs.txt");
                return null;
            }
        }
        public List<PresentMask> OrderByCategory()
        {
            try
            {
                var presents = _presentDal.GetPresent();
                var p = presents.OrderBy(x => x.Category).ToList();
                return p;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to order by category,exception{e.Message}", "logs.txt");
                return null;
            }
        }
    }
}
