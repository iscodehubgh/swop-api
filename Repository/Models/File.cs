using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class File
    {
        public string Id { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string? ArticleId { get; set; }

        public virtual Article? Article { get; set; }
    }
}
