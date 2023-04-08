namespace Repository
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(string id);

        //Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(string id, TEntity entity);

        Task<TEntity> Delete(string id);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(string id);

        IQueryable<TEntity> GetQueryable();

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task SaveChangesAsync();
    }
}
