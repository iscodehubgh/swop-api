using Repository.DTOs.Articles;
using Repository.Models;

namespace Services.Services.Articles
{
    public interface IArticlesService
    {
        Task<IEnumerable<ArticlesDTO>> GetArticles();
        Task<Article> GetArticle(string id);
        Task<Article> PostArticle(Article article);
        Task<Article> PutArticle(string id, Article article);
        Task<Article> DeleteArticle(string id);
    }
}
