using Library.Entity;
using Library.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewModels.Author;
using Library.ViewModels.Journal;
using Library.ViewModels;

namespace Library.BLL.Services
{
    public class JournalSevice
    {
        private JournalRepository _journalRepository;
        private PublishingHouseRepository _publishingHouseRepository;
        private AuthorRepository _authorRepository;
        private AuthorJournalRepository _authorJournalRepository;


        public JournalSevice()
        {
            _journalRepository = new JournalRepository();
            _publishingHouseRepository = new PublishingHouseRepository();
            _authorJournalRepository = new AuthorJournalRepository();
            _authorRepository = new AuthorRepository();
        }

        public IEnumerable<JournalViewModel> GetAll()
        {
            return _journalRepository.GetAll();
        }

        public void DeleteJournal(int id)
        {
            _journalRepository.Remove(new Journal() { Id = id });
        }

        public IEnumerable<AuthorFullNameViewModel> GetJournalAuthors(int id)
        {
            return _authorRepository.GetListAuthorsByJournalId(id).Select(a => new AuthorFullNameViewModel(a));
        }

        public IEnumerable<PublishingHouseViewModel> GetAllPublisingHouse()
        {
            return _publishingHouseRepository.GetAll().Select(p => new PublishingHouseViewModel(p));
        }

        public void CreateJournal(JournalViewModel model)
        {
            var insertedId = _journalRepository.Create(model);
            _authorJournalRepository.AddJournalAuthors(GetAuthorId(model.Authors), insertedId);
        }

        public void UpdateJournal(JournalViewModel model)
        {
            _journalRepository.Update(model);
            _authorJournalRepository.UpdateJournalAuthors(GetAuthorId(model.Authors), model.JournalId);
        }


        private List<int> GetAuthorId(ICollection<AuthorFullNameViewModel> list)
        {
            return list.Select(a => a.AuthorId).ToList();
        }
    }
}
