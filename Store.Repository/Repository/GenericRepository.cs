using Microsoft.EntityFrameworkCore;
using Store.Data.Data.Contexts;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
       => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(TKey? id)
        => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task AddAsync(TEntity entity)
        => await _dbContext.AddAsync(entity);


        public void Update(TEntity entity)
        => _dbContext.Update(entity);

        public void Delete(TEntity entity)
       => _dbContext.Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetWitSpecificationAllAsync(ISpecifications<TEntity> spec)
      => await SpecificationEvaluater<TEntity,TKey>.GetQuery(_dbContext.Set<TEntity>(),spec).ToListAsync();

        public async Task<TEntity> GetWitSpecificationByIdAsync(ISpecifications<TEntity> spec)
       => await SpecificationEvaluater<TEntity, TKey>.GetQuery(_dbContext.Set<TEntity>(), spec).FirstOrDefaultAsync();

        public async Task<int> GetCountSpecificationAsy(ISpecifications<TEntity> spec)
            => await SpecificationEvaluater<TEntity, TKey>.GetQuery(_dbContext.Set<TEntity>(), spec).CountAsync();

    }
}
