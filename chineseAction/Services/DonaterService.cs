using chineseAction.Dal;
using chineseAction.Models;

namespace chineseAction.Services
{
    public class DonaterService : IDonaterService

    {
        private readonly IPresentDal _presentDal;
        private readonly IDonaterDal _donatorDal;
        public DonaterService(IDonaterDal donatorDal, IPresentDal presentDal)
        {
            _donatorDal = donatorDal;
            _presentDal = presentDal;
        }
        public bool Add(Donater newDonater)
        {
            return _donatorDal.Add(newDonater);
        }
        public void Update(int id, string? FullName, string? Phon, string? Mail)
        {
            Donater newDonater = new Donater();
            newDonater.FullName = FullName;
            newDonater.Phone = Phon;
            newDonater.Mail = Mail;
            _donatorDal.Update(id, newDonater);
        }


        public List<Donater> Delete(int id)
        {
            _donatorDal.Delete(id);
            return new List<Donater>();
        }

        public List<Donater> GetDonater()
        {
            var presents = _donatorDal.GetDonater();
            return presents;
        }

        public List<Donater> GetByName(string name)
        {
            var donaters = _donatorDal.GetByName(name);
            return donaters;
        }

        public List<Donater> GetByMail(string mail)
        {
            var donaters = _donatorDal.GetByMail(mail);
            return donaters;
        }

        public Donater GetByPresent(int presentId)
        {
            //PresentMask present = _presentDal.GetById(presentId);
            //string donater = (string)present.Donater;
            //if (present.Donater != null)
            //{
            //    Donater d = _donatorDal.GetByName(donater);
            //    return d;
            //}
            return new Donater();
        }

        public Donater GetById(int id)
        {
            Donater donater = _donatorDal.GetById(id);
            return donater;
        }
    }
        
}
