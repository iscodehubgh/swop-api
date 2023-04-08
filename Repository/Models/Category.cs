using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ParentId { get; set; }

        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
    }
}
