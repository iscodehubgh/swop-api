namespace Repository.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Trades = new HashSet<Trade>();
        }

        public Guid Id { get; set; }
        public Guid? SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public int? StatusId { get; set; }

        public virtual Status? Status { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
