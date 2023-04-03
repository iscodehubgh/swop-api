using Repository.DTOs.Articles;
using Repository.Models;
using Repository.Repositories.Articles;
using Services.Utils.Mappers;

namespace Services.Services.Articles
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;
        public ArticlesService(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<ArticlesDTO>> GetArticles()
        {
            return (await _articlesRepository.GetArticles()).Select(x => ArticlesMapper.MapArticlesFromEntityToDTO(x)).ToList();
        }

        public async Task<Article> GetArticle(string id)
        {
            return await _articlesRepository.GetArticle(id);
        }        

        public async Task<Article> PostArticle(Article article)
        {
            return await _articlesRepository.PostArticle(article);
        }

        public async Task<Article> PutArticle(string id, Article article)
        {
            return await _articlesRepository.PutArticle(id, article);
        }

        public async Task<Article> DeleteArticle(string id)
        {
            return await _articlesRepository.DeleteArticle(id);
        }
    }
}
