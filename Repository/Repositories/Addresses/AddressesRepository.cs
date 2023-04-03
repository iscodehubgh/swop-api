using Repository.Models;

namespace Repository.Repositories.Addresses
{
    public class AddressesRepository : GenericRepository<Address>, IAddressesRepository
    {
        public AddressesRepository(swopContext dbContext) : base(dbContext)
        {
        }
    }
}
