using Library.Entity;
using Library.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewModels;

namespace Library.BLL.Services
{
    public class NewspaperService
    {
        private NewspaperRepository _newspaperRepository;
        private PublishingHouseRepository _publishingHouseRepository;

        public NewspaperService()
        {
            _newspaperRepository = new NewspaperRepository();
            _publishingHouseRepository = new PublishingHouseRepository();
        }

        public IEnumerable<NewspaperViewModel> GetAll()
        {
            return _newspaperRepository.GetAll();
        }

        public void Create(Newspaper value)
        {
            _newspaperRepository.Create(value);
        }

        public void Edit(Newspaper value)
        {
            _newspaperRepository.Update(value);
        }

        public void Delete(int id)
        {
            _newspaperRepository.Remove(new Newspaper() { Id = id });
        }
    }
}
