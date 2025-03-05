using chineseAction.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace chineseAction.Dal
{
    public class PresentDal: IPresentDal
    {
        private readonly ProjectDbContext _context;
        private readonly IDonaterDal _donatorDal;

        public PresentDal(ProjectDbContext context, IDonaterDal donatorDal)
        {
            _donatorDal = donatorDal;
            _context = context;
        }

        public List<PresentMask> GetPresent()
        {
            var PresentWithUser = _context.Presents.Include(x => x.Donater).Select(x => new PresentMask
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Image = x.Image,
                NumBuyers=x.NumBuyers,
                Donater = x.Donater.FullName,
                Category=x.Category.Name,
            }).ToList();

            return PresentWithUser;
        }


        public PresentMask Add(PresentMask present)
        {
            if (present != null)
            {
                Category c = _context.Categorys.First(x => x.Name == present.Category);
                Donater d = _donatorDal.GetByName(present.Donater);
                Present p = new Present();
                p.Id = 0;
                p.Name = present.Name;
                p.Price = present.Price;
                p.Description = present.Description;
                p.Image = present.Image;
                p.DonaterId=d.Id;
                p.CategoryId = c.Id;
                _context.Presents.Add(p);
                _context.SaveChanges();
                return present;
            }
            return null;
        }

        public void Delete(int id)
        {
            Present? present = _context.Presents.Find(id);

            if (present != null)
            {
                _context.Presents.Remove(present);
                _context.SaveChanges();
            }
        }
        public void Update( Present newPresent)
        {
            //Present? thisPresent = _context.Presents.Find(id);
            //if (newPresent.Name != null)
            //    thisPresent.Name = newPresent.Name;

            //if (newPresent.Description != null)
            //    thisPresent.Description = newPresent.Description;

            //if (newPresent.CategoryId != null)
            //    thisPresent.CategoryId = newPresent.CategoryId;

            //if (newPresent.Image != null)
            //    thisPresent.Image = newPresent.Image;
            //if (newPresent.Price != null)
            //    thisPresent.Price = newPresent.Price;

            //if (newPresent.DonaterId != null)
            //    thisPresent.DonaterId = newPresent.DonaterId;

            //if (newPresent.NumBuyers != null)
            //    thisPresent.NumBuyers = newPresent.NumBuyers;

            _context.Presents.Update(newPresent);
            _context.SaveChanges();
        }
        public PresentMask GetById(int id)
        {
            var PresentWithUser = _context.Presents.Include(x => x.Donater).Select(x => new PresentMask
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Image = x.Image,
                NumBuyers = x.NumBuyers,
                Donater = x.Donater.FullName,
                Category = x.Category.Name,
            }).ToList();
            var p = PresentWithUser.FirstOrDefault(x=>x.Id==id);
            return p;
        }

        public List<Present> GetByBuyers(int num)
        {
           List<Present>? presents = _context.Presents.Where(x => x.NumBuyers == num).ToList();
            return presents;
        }

        public List<Present> GetByName(string name)
        {
            List<Present>? presents = _context.Presents.Where(x => x.Name == name).ToList();
            return presents;
        }

        public List<PresentMask> GetByDonaterId(int id)
        {
            var PresentWithUser = _context.Presents.Include(x => x.Donater).Where(x => x.DonaterId == id).Select(x => new PresentMask
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Image = x.Image,
                NumBuyers = x.NumBuyers,
                Donater = x.Donater.FullName,
                Category = x.Category.Name,
            }).ToList();

            return PresentWithUser;
        }

        //public List<Present> GetByDonaterId(int id)
        //{
        //    List<Present>? presents = _context.Presents.Where(x => x.DonaterId == id).ToList();
        //    return presents;
        //}


    }
}
