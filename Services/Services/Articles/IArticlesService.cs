using Repository.DTOs.Articles;
using Repository.Models;

namespace Services.Services.Articles
{
    public interface IArticlesService
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(string id);
        Task<Article> PostArticle(ArticlesDTO article, string userId);
        Task<Article> PutArticle(string id, ArticlesDTO article);
        Task<Article> DeleteArticle(string id);
    }
}
