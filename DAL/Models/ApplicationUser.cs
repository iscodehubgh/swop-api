using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Addresses = new HashSet<Address>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Address> Addresses { get; } = new List<Address>();
    }
}
