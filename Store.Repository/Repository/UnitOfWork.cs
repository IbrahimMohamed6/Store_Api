using Store.Data.Data.Contexts;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System.Collections;

namespace Store.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;
        private Hashtable _Repositories;


        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CompleteAsync()
      =>await _dbContext.SaveChangesAsync();
        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if( _Repositories is null )
                _Repositories = new Hashtable();

            var EntityKey=typeof(TEntity).Name;

            if(!_Repositories.ContainsKey(EntityKey))
            {
                var RepositoryType=typeof(GenericRepository<,>);
                var RepositoryInstance=Activator.CreateInstance(RepositoryType.MakeGenericType(typeof(TEntity),typeof(TKey)),_dbContext);
                _Repositories.Add(EntityKey, RepositoryInstance);
            }
            return (IGenericRepository<TEntity, TKey>)_Repositories[EntityKey];
        }
    }
}
