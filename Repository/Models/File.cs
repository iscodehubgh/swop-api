namespace Repository.Models
{
    public partial class File
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = null!;
        public Guid? ArticleId { get; set; }

        public virtual Article? Article { get; set; }
    }
}
