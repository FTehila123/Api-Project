using chineseAction.Models;
using Microsoft.EntityFrameworkCore;

namespace chineseAction.Dal
{
    public class DonaterDal: IDonaterDal
    {
        private readonly ProjectDbContext _context;
        public DonaterDal(ProjectDbContext context)
        {
            _context = context;
        }
        public List<Donater> GetDonater()
        {
            return _context.Donaters.ToList();
        }


        public bool Add(Donater donater)
        {
            if (donater != null)
            {
                _context.Donaters.Add(donater);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            Donater? donater = _context.Donaters.Find(id);

            if (donater != null)
            {
                _context.Donaters.Remove(donater);
                _context.SaveChanges();
            }
        }
        public void Update( Donater newPresent)
        {
            //Donater? thisPresent = _context.Donaters.Find(id);
            //if (newPresent.FullName != null)
            //    thisPresent.FullName = newPresent.FullName;

            //if (newPresent.Phone != null)
            //    thisPresent.Phone = newPresent.Phone;

            //if (newPresent.Mail != null)
            //    thisPresent.Mail = newPresent.Mail;
            _context.Donaters.Update(newPresent);
            _context.SaveChanges();
        }

        public Donater GetByName(string name)
        {
            Donater? donaters = _context.Donaters.FirstOrDefault(x => x.FullName == name);
            return donaters;
        }

        public List<Donater> GetByMail(string mail)
        {
            List<Donater>? donaters = _context.Donaters.Where(x => x.Mail == mail).ToList();
            return donaters;
        }

        public Donater GetById(int id)
        {
            Donater? donater = _context.Donaters.Find(id);
            return donater;
        }

    }
}
