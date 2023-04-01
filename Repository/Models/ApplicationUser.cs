using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
