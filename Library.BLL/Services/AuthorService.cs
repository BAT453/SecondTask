using System.Collections.Generic;
using System.Linq;
using Library.Entity;
using Library.DAL.Repository;

namespace Library.BLL.Services
{
    public class AuthorService
    {
        private AuthorRepository _authorRepository;

        public AuthorService()
        {
            _authorRepository = new AuthorRepository();
        }

        public IEnumerable<Author> GetAuthors()
        {
            var result = _authorRepository.GetAll();
            return result;
        }

        public void CreateAuthor(Author author)
        {
            _authorRepository.Create(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Remove(new Author() { Id = id });
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
