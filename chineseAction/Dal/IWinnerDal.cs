using chineseAction.Models;

namespace chineseAction.Dal
{
    public interface IWinnerDal
    {
        bool Add(Winner winner);
        List<WinnerMask> GetWinners();
    }
}