using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class File
{
    [Key]
    public int Id { get; set; }

    public int ArticleId { get; set; }

    public string Path { get; set; } = null!;

    public virtual Article Article { get; set; } = null!;
}
