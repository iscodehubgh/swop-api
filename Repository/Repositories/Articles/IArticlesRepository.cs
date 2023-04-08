using Repository.DTOs.Articles;
using Repository.Models;

namespace Repository.Repositories.Articles
{
    public interface IArticlesRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(string id);
        Task<Article> PutArticle(string id, ArticlesDTO article);
        Task<Article> PostArticle(ArticlesDTO article, string userId);
        Task<Article> DeleteArticle(string id);
    }
}
