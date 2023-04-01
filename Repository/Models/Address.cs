namespace Repository.Models
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? State { get; set; }
        public string? PostCode { get; set; }
        public Guid? UserId { get; set; }
    }
}
