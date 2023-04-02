using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Trades = new HashSet<Trade>();
        }

        public string Id { get; set; } = null!;
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public int? StatusId { get; set; }

        [InverseProperty("OfferReceivers")]
        public virtual ApplicationUser? Receiver { get; set; }
        [InverseProperty("OfferSenders")]
        public virtual ApplicationUser? Sender { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
