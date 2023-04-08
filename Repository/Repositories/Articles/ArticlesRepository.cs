using Microsoft.EntityFrameworkCore;
using Repository.DTOs.Articles;
using Repository.Models;

namespace Repository.Repositories.Articles
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly swopContext _context;

        public ArticlesRepository(swopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            if (_context.Articles == null)
            {
                return new List<Article>();
            }

            return await _context.Articles
                                 .Select(x => new Article
                                 {
                                     Id = x.Id,
                                     Title = x.Title,
                                     Description = x.Description,
                                     User = x.User,
                                     Files = x.Files
                                 })
                                 .ToListAsync();
        }

        public async Task<Article> GetArticle(string id)
        {
            if (_context.Articles == null)
            {
                return new Article();
            }

            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return new Article();
            }

            return article;
        }

        public async Task<Article> PostArticle(ArticlesDTO article, string userId)
        {
            if (_context.Articles == null)
            {
                return new Article();
            }

            var newArticle = _context.Articles.Add(new Article
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                UserId = userId
            });

            await _context.SaveChangesAsync();

            return newArticle.Entity;
        }

        public async Task<Article> PutArticle(string id, ArticlesDTO article)
        {
            if (!ArticleExists(id))
            {
                return new Article();
            }

            _context.Entry(article).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            //return article;
            return new Article();
        }

        public async Task<Article> DeleteArticle(string id)
        {
            if (_context.Articles == null)
            {
                return new Article();
            }

            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return new Article();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return article;
        }

        private bool ArticleExists(string id)
        {
            return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
