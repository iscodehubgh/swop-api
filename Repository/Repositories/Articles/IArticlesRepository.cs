using Repository.Models;

namespace Repository.Repositories.Articles
{
    public interface IArticlesRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(string id);
        Task<Article> PutArticle(string id, Article article);
        Task<Article> PostArticle(Article article);
        Task<Article> DeleteArticle(string id);
    }
}
