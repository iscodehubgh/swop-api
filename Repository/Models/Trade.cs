namespace Repository.Models
{
    public partial class Trade
    {
        public Guid Id { get; set; }
        public Guid? OfferId { get; set; }
        public Guid? ArticleId { get; set; }
        public string Quantity { get; set; } = null!;
        public bool IsRequested { get; set; }

        public virtual Article? Article { get; set; }
        public virtual Offer? Offer { get; set; }
    }
}
