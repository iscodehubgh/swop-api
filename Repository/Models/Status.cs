using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Status
    {
        public Status()
        {
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
