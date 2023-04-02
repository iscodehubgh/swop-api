using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Trade
    {
        public string Id { get; set; } = null!;
        public string? OfferId { get; set; }
        public string? ArticleId { get; set; }
        public string Quantity { get; set; } = null!;
        public bool IsRequested { get; set; }

        public virtual Article? Article { get; set; }
        public virtual Offer? Offer { get; set; }
    }
}
