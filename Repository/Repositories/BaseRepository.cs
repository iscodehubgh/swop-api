using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class BaseRepository
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }
    }
}
