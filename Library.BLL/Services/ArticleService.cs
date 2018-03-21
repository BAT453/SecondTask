using Library.Entity;
using Library.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewModels.Article;
using Library.ViewModels.Author;

namespace Library.BLL.Services
{
    public class ArticleService
    {
        private ArticleRepository _articleRepository;
        private NewspaperRepository _newspaperRepository;
        private AuthorArticleRepository _authorArticleRepository;

        public ArticleService()
        {
            _articleRepository = new ArticleRepository();
            _newspaperRepository = new NewspaperRepository();
            _authorArticleRepository = new AuthorArticleRepository();
        }

        public void CreateArticle(ArticleViewModel value)
        {
            int insertedArticleId = _articleRepository.Create(value);
            var authorIds = value.Authors.Select(a => a.AuthorId).ToList();

            _authorArticleRepository.AddArticleAuthors(authorIds, insertedArticleId);
        }

        public IEnumerable<AuthorFullNameViewModel> GetArticleAuthors(int ArticleId)
        {
            return _articleRepository.GetArticleAuthors(ArticleId);
        }

        public void UpdateArticle(ArticleViewModel value)
        {
            _articleRepository.Update(value);

            var authorIds = value.Authors.Select(a => a.AuthorId).ToList();

            _authorArticleRepository.UpdateArticleAuthors(authorIds, value.ArticleId);
        }

        public IEnumerable<ArticleViewModel> GetArticles()
        {
            return _articleRepository.GetAll();
        }

        public void DeleteArticle(int id)
        {
            _articleRepository.Remove(new Article() { Id = id});
        }
    }
}
