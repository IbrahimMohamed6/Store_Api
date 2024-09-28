using Store.Data.Entities;
using Store.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TKey? id);


        Task<IReadOnlyList<TEntity>> GetWitSpecificationAllAsync(ISpecifications<TEntity> spec);

        Task<TEntity> GetWitSpecificationByIdAsync(ISpecifications<TEntity> spec);
        Task<int> GetCountSpecificationAsy(ISpecifications<TEntity> spec);


        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
