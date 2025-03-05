using chineseAction.Models;

namespace chineseAction.Dal
{
    public interface IDonaterDal
    {
        public List<Donater> GetDonater();
        public bool Add(Donater donater);
        public void Delete(int id);
        public void Update(Donater newPresent);
        public Donater GetByName(string name);
        public List<Donater> GetByMail(string mail);
        public Donater GetById(int id);
    }
}
