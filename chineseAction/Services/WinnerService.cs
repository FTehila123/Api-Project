using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services.Logger;
using Humanizer;

namespace chineseAction.Services
{
    public class WinnerService : IWinnerService
    {
        private readonly IWinnerDal _winnerDal;
        private readonly ILoggerService _logger;
        private readonly ICustomerPresentDal _customerPresentDal;
        private readonly IPresentDal _presentDal;
        public WinnerService(IWinnerDal winnerDal, ICustomerPresentDal customerPresentDal, ILoggerService logger, IPresentDal presentDal)
        {
            _logger = logger;
            _winnerDal = winnerDal;
            _customerPresentDal = customerPresentDal;
            _presentDal = presentDal;

        }

        public IEnumerable<WinnerMask> GetWinners()
        {
            try {
                return _winnerDal.GetWinners();
            }
            catch(Exception e)
            {
                _logger.Log($"failed to get all the winners,exception{e.Message}", "logs.txt");
                return null;
            }
            
        }

        public Customer Lottery(int presenId)
        {
            try
            {
                PresentMask pp = _presentDal.GetById(presenId);
                List<Customer> p = _customerPresentDal.CustomerForPresent(presenId).ToList();
                Random rng = new Random();
                int ind = rng.Next(p.Count());
                Winner winner = new Winner();
                winner.PresentId = presenId;
                winner.CustomerId = p[ind].Id;
                int? revenue = p.Count() * pp.Price;
                _logger.Log($"for presen)t-{presenId}:{p[ind].FullName}", "winners.txt");
                _logger.Log($"for present-{presenId}:{revenue}", "revenue.txt");
                SendEmailToWinner(p[ind], presenId);
                if (_winnerDal.Add(winner))
                {
                    return p[ind];
                }
                return null;
            }
            catch(Exception e)
            {
                _logger.Log($"failed to use the function lottery on the present:{presenId},exception{e.Message}", "logs.txt");
                return null;
            }
        }


        private void SendEmailToWinner(Customer winner, int id)
        {
            try
            {
                using (var smtpClient = new System.Net.Mail.SmtpClient("smtp.office365.com", 587))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("38327796942@mby.co.il", "Student@264");
                    smtpClient.EnableSsl = true;

                    var mailMessage = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress("38327796942@mby.co.il"),
                        Subject = "(נסיון שליחת מייל פרויקט אנגולר) Congratulations! You've won!",
                        Body = $"Dear {winner.FullName},\n\n" +
                               $"Congratulations! You have won prize {id} in our raffle.\n\n" +
                               "Please contact us to claim your prize.\n\n" +
                               "Best regards,\nThe Team",
                        IsBodyHtml = false,
                    };
                    Console.WriteLine(winner.Mail);
                    mailMessage.To.Add(winner.Mail);

                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                _logger.Log($"Failed to send email: {ex.Message}", "logs.txt");
            }
        }

    }
}
