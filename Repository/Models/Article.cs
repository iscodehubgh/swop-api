namespace Repository.Models
{
    public partial class Article
    {
        public Article()
        {
            Files = new HashSet<File>();
            Trades = new HashSet<Trade>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? UserId { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
