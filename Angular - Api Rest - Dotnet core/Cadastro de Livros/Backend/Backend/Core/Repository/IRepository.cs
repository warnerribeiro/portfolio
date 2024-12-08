namespace Core.Repository
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> Get();

        Task<TEntity?> GetAsync(int id);

        Task SaveChangesAsync();

        void Update(TEntity entity);
    }
}