using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Article
    {
        public Article()
        {
            Files = new HashSet<File>();
            Trades = new HashSet<Trade>();
        }

        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
