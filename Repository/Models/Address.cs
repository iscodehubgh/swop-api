using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public partial class Address : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? State { get; set; }
        public string? PostCode { get; set; }
        public string? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; } = null!;
    }
}
