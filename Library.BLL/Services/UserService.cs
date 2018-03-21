using Library.Entity.Enums;
using Library.Entity;
using Library.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewModels.Book;
using Library.ViewModels.SearchByAuthor;
using Library.ViewModels.Author;

namespace Library.BLL.Services
{
    public class UserService
    {
        private BookRepository _bookRepository;
        private UserRepository _userRepository;
        private JournalRepository _journalRepository;
        private NewspaperRepository _newspaperRepository;

        public UserService()
        {
            _bookRepository = new BookRepository();
            _userRepository = new UserRepository();
            _journalRepository = new JournalRepository();
            _newspaperRepository = new NewspaperRepository();
        }

        public IEnumerable<GeneralInformation> GetPublications(int idTypePublication)
        {
            var listPublications = new List<GeneralInformation>();
            var publication = (TypeOfPublication)idTypePublication;

            if (publication == TypeOfPublication.Newspaper)
            {
                listPublications.AddRange(_newspaperRepository.GetAll().Select(x => new GeneralInformation(x)));
            }
            if (publication == TypeOfPublication.Journal)
            {
                listPublications.AddRange(_journalRepository.GetAll().Select(x => new GeneralInformation(x)));
            }
            if (publication == TypeOfPublication.Book)
            {
                listPublications.AddRange(_bookRepository.GetAll().Select(x => new GeneralInformation(x)));
            }
     
            return listPublications;
        }

        public IEnumerable<GeneralInformation> GetUserPublications(int idTypePublication, string userId )
        {
            var listPublications = new List<GeneralInformation>();
            var publication = (TypeOfPublication)idTypePublication;

            if (publication == TypeOfPublication.Newspaper)
            {
                listPublications.AddRange(_newspaperRepository.GetListNewspapersByUserId(userId).Select(x => new GeneralInformation(x)));
            }
            if (publication == TypeOfPublication.Journal)
            {
                listPublications.AddRange(_journalRepository.GetListJournalsByUserId(userId).Select(x => new GeneralInformation(x)));
            }
            if (publication == TypeOfPublication.Book)
            {
                listPublications.AddRange(_bookRepository.GetListBooksByUserId(userId).Select(x => new GeneralInformation(x)));
            }

            return listPublications;
        }

        public void AddPublicationToUser(GeneralInformation information, string userId)
        {
            var publication = (TypeOfPublication)System.Enum.Parse(typeof(TypeOfPublication), information.TypeOfPublication);

            if (publication == TypeOfPublication.Article)
            {
                var newspaper = _newspaperRepository.GetNewspaperByArticleId(information.PublicationId);
                _userRepository.AddNewspaperToUser(new UserNewspaper() { NewspaperId = newspaper.Id, UserId = userId });
            }
            if (publication == TypeOfPublication.Journal)
            {
                _userRepository.AddJournalToUser(new UserJournal() { JournalId = information.PublicationId, UserId = userId });
            }
            if (publication == TypeOfPublication.Book)
            {
                _userRepository.AddBookToUser(new UserBook() { BookId = information.PublicationId, UserId = userId });
            }
        }

        public void DeletePublicationFromUser(GeneralInformation information, string userId)
        {
            var publication = (TypeOfPublication)System.Enum.Parse(typeof(TypeOfPublication), information.TypeOfPublication);

            if (publication == TypeOfPublication.Newspaper)
            {
                _userRepository.DeleteNewspaperFromUser(information.PublicationId, userId);
            }
            if (publication == TypeOfPublication.Journal)
            {
                _userRepository.DeleteJournalFromUser(information.PublicationId, userId);
            }
            if (publication == TypeOfPublication.Book)
            {
                _userRepository.DeleteBookFromUser(information.PublicationId, userId);
            }
        }
    }
}
