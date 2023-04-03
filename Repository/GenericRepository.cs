using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity, new()
    {
        private readonly swopContext _dbContext;

        public GenericRepository(swopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            if (_dbContext.Set<TEntity>() == null)
                return new List<TEntity>();

            return await _dbContext.Set<TEntity>()
                                   .ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            if (_dbContext.Set<TEntity>() == null)
                return new TEntity();

            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
                return new TEntity();

            return entity;
        }

        public async Task<TEntity> Create(TEntity entity)
        {

            if (_dbContext.Set<TEntity>() == null)
                return new TEntity();

            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Update(string id, TEntity entity)
        {
            if (!Exists(id))
                return new TEntity();

            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Delete(string id)
        {
            if (_dbContext.Set<TEntity>() == null)
                return new TEntity();

            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
                return new TEntity();

            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        private bool Exists(string id)
        {
            return (_dbContext.Set<TEntity>()?.Any(x => x.Id == id)).GetValueOrDefault();
        }
    }
}
