using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public partial class File
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string? ArticleId { get; set; }

        public virtual Article? Article { get; set; }
    }
}
