using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public partial class Category
{
    public Category()
    {
        Articles = new HashSet<Article>();
        InverseParent = new HashSet<Category>();
    }

    [Key]
    public int Id { get; set; }

    public int ParentId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; } = new List<Article>();

    public virtual ICollection<Category> InverseParent { get; } = new List<Category>();

    public virtual Category Parent { get; set; } = null!;
}
