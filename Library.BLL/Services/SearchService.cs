 using Library.Entity;
using Library.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewModels.SearchByAuthor;

namespace Library.BLL.Services
{
    public class SearchService
    {
        private JournalRepository _journalRepository;
        private BookRepository _bookRepository;
        private ArticleRepository _articleRepository;


        public SearchService()
        {
            _journalRepository = new JournalRepository();
            _bookRepository = new BookRepository();
            _articleRepository = new ArticleRepository();
        }

        public IEnumerable<GeneralInformation> GetPublicationsByAuthors(AuthorsViewModel model)
        {
            return this.GetPublicationsByAuthorIds(model.Authors);
        }

        public IEnumerable<GeneralInformation> GetPublicationsByAuthorIds(List<int> authors)
        {
            var generalInformation = new List<GeneralInformation>();

            GetBookInformation(authors, ref generalInformation);
            GetJournalInformation(authors, ref generalInformation);
            GetArticleInformation(authors, ref generalInformation);

            return generalInformation;
        }

        private void GetArticleInformation(List<int> listAuthor, ref List<GeneralInformation> list)
        {
            list.AddRange(_articleRepository.GetArticlesByListAuthors(listAuthor).Select(x => new GeneralInformation(x)));
        }

        private void GetBookInformation(List<int> listAuthor, ref List<GeneralInformation> list)
        {
            list.AddRange(_bookRepository.GetBooksByAuthorId(listAuthor).Select(x => new GeneralInformation(x)));
        }

        private void GetJournalInformation(List<int> listAuthor, ref List<GeneralInformation> list)
        {
            list.AddRange(_journalRepository.GetJournalsByListAuthorIds(listAuthor).Select(x => new GeneralInformation(x)));
        }
    }
}
