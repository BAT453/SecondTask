using Library.Entity;
using Library.DAL.Repository;
using System.Collections.Generic;
using System.Linq;
using Library.ViewModels.Author;
using Library.ViewModels.Book;

namespace Library.BLL.Services
{
    public class BookService
    {
        private BookRepository _bookRepository;
        private AuthorRepository _authorRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
            _authorRepository = new AuthorRepository();
        }

        public IEnumerable<BookViewModel> GetBooks()
        {
            return _bookRepository.GetAll();
        }

        public void CreateBook(Book book)
        {
            _bookRepository.Create(book);
        }

        public void DeleteBook(int bookID)
        {
            _bookRepository.Remove(new Book() {Id = bookID });
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }

        public IEnumerable<AuthorFullNameViewModel> GetAuthorsForDropDown()
        {
           return _authorRepository.GetAll().Select(a => new AuthorFullNameViewModel(a));
        }
    }
}
