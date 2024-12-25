using chineseAction.Models;

namespace chineseAction.Dal
{
    public interface IPresentDal
    {
        public List<PresentMask> GetPresent();
        public bool Add(Present present);
        public void Delete(int id);
        public PresentMask GetById(int id);
        public void Update(int id, Present newPresent);
        public List<Present> GetByBuyers(int num);
        public List<Present> GetByName(string name);
        public List<Present> GetByDonaterId(int id);
    }
}
