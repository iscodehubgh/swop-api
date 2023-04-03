namespace Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(string id);

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(string id, TEntity entity);

        Task<TEntity> Delete(string id);
    }
}
