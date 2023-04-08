using Microsoft.AspNetCore.Http;

namespace Repository.DTOs.Articles
{
    public class ArticlesDTO
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IList<IFormFile>? Images { get; set; } = new List<IFormFile>();
    }
}
