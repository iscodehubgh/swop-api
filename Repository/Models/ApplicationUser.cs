using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Addresses = new HashSet<Address>();
            Articles = new HashSet<Article>();
            OfferReceivers = new HashSet<Offer>();
            OfferSenders = new HashSet<Offer>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Offer> OfferReceivers { get; set; }
        public virtual ICollection<Offer> OfferSenders { get; set; }
    }
}
