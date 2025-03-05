using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services.Logger;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace chineseAction.Services
{
    public class DonaterService : IDonaterService

    {
        private readonly ILoggerService _logger;
        private readonly IPresentDal _presentDal;
        private readonly IDonaterDal _donatorDal;
        public DonaterService(IDonaterDal donatorDal, IPresentDal presentDal, ILoggerService logger)
        {
            _logger = logger;
            _donatorDal = donatorDal;
            _presentDal = presentDal;
        }
        public bool Add(Donater newDonater)
        {
            try
            {
                return _donatorDal.Add(newDonater);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to add donater {newDonater.Id},exception{e.Message}", "logs.txt");
                return false;
            }
        }
        public void Update(Donater d)
        {
            try
            {
                Donater newDonater = new Donater();
                _donatorDal.Update(d);
            }
            catch (Exception e)
            {
                _logger.Log($"failed to update donater {d.Id},exception{e.Message}", "logs.txt");
            }
        }


        public List<Donater> Delete(int id)
        {
            try
            {
                _donatorDal.Delete(id);
                return new List<Donater>();
            }
            catch (Exception e)
            {
                _logger.Log($"failed to delete donater {id},exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public List<Donater> GetDonater()
        {
            try
            {
                var presents = _donatorDal.GetDonater();
                return presents;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get all the donaters,exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public Donater GetByName(string name)
        {
            try
            {
                var donaters = _donatorDal.GetByName(name);
                return donaters;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get the donater {name},exception{e.Message}", "logs.txt");
                return null;
            }
        }

        public List<Donater> GetByMail(string mail)
        {
            try
            {
                var donaters = _donatorDal.GetByMail(mail);
                return donaters;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get the donater by mail {mail},exception{e.Message}", "logs.txt");
                return null;
            }
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
            try
            {
                Donater donater = _donatorDal.GetById(id);
                return donater;
            }
            catch (Exception e)
            {
                _logger.Log($"failed to get the donater {id},exception{e.Message}", "logs.txt");
                return null;
            }
        }
    }
        
}
