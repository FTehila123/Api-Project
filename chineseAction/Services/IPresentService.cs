using chineseAction.Models;

namespace chineseAction.Services
{
    public interface IPresentService
    {
        List<PresentMask> GetPresent();
        public bool Add(Present newPresent);
        public List<Present> Delete(int id);
        public PresentMask GetById(int id);
        public void Update(int Id, string Name, string Description, int? CategoryId, int? NumBuyers, string? Image, int Price, int DonaterId);
        public List<Present> GetByBuyers(int num);
        public List<Present> GetByName(string name);
        public List<Present> GetByDonaterId(int id);
        public List<PresentMask> GetByPrice();
        public PresentMask GetByPopular();
        public PresentMask GetByMostExpensive();
            public List<PresentMask> OrderByCategory();
    }
}
