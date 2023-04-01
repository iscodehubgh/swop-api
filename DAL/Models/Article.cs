using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class Article
{
    public Article()
    {
        Files = new HashSet<File>();
    }

    [Key]
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<File> Files { get; } = new List<File>();
}
