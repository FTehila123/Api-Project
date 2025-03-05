using chineseAction.Models;
using Microsoft.EntityFrameworkCore;

namespace chineseAction.Dal
{
    public class WinnerDal : IWinnerDal
    {
        private readonly ProjectDbContext _context;

        public WinnerDal(ProjectDbContext context)
        {
            _context = context;
        }

        public bool Add(Winner winner)
        {

            if (winner != null)
            {
                _context.Winners.Add(winner);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<WinnerMask> GetWinners()
        {
                var win = from w in _context.Winners
                          join c in _context.Customers on w.CustomerId equals c.Id
                          join p in _context.Presents on w.PresentId equals p.Id
                          select new WinnerMask
                          {
                              Id = w.Id,
                              PresentName = p.Name,
                              PresentId = p.Id,
                              CustomerName = c.FullName,
                              Mail = c.Mail
                          };
                if (win != null)
                    return win.ToList();
                return null;
            }
     
    }
}
