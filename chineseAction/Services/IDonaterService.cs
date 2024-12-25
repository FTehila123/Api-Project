using chineseAction.Models;

namespace chineseAction.Services
{
    public interface IDonaterService
    {
        public List<Donater> GetDonater();
        public List<Donater> Delete(int id);
        public void Update(int id, string? FullName, string? Phon, string? Mail);
        public bool Add(Donater newDonater);
        public List<Donater> GetByName(string name);
        public List<Donater> GetByMail(string mail);
        public Donater GetByPresent(int presentId);
        public Donater GetById(int id);
    }
}
