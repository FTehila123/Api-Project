using chineseAction.Models;

namespace chineseAction.Dal
{
    public interface IDonaterDal
    {
        public List<Donater> GetDonater();
        public bool Add(Donater donater);
        public void Delete(int id);
        public void Update(int id, Donater newPresent);
        public List<Donater> GetByName(string name);
        public List<Donater> GetByMail(string mail);
        public Donater GetById(int id);
    }
}
