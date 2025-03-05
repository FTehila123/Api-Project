using chineseAction.Models;

namespace chineseAction.Services
{
    public interface IWinnerService
    {
        IEnumerable<WinnerMask> GetWinners();
        Customer Lottery(int presenId);
    }
}