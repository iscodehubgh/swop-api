using Repository.DTOs.Articles;
using Repository.Models;

namespace Services.Utils.Mappers
{
    public static class ArticlesMapper
    {
        public static ArticlesDTO MapArticlesFromEntityToDTO(Article article)
        {
            return new ArticlesDTO
            {
                Title = article.Title,
                Description = article.Description
            };
        }
    }
}
