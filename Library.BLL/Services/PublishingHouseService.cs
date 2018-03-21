 using Library.Entity;
using Library.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public class PublishingHouseService
    {
        private PublishingHouseRepository _publishingHouseRepository;

        public PublishingHouseService()
        {
            _publishingHouseRepository = new PublishingHouseRepository();
        }

        public IEnumerable<PublishingHouse> GetAll()
        {
            return _publishingHouseRepository.GetAll();
        }

        public void EditPublishHouse(PublishingHouse model)
        {
            _publishingHouseRepository.Update(model);
        }

        public void CreatePublisingHouse(string model)
        {
            _publishingHouseRepository.Create(new PublishingHouse() { PublishingHouseName = model });
        }

        public void DeletePublishingHouse(int id)
        {
            _publishingHouseRepository.Remove(new PublishingHouse() { Id = id});
        }
    }
}
