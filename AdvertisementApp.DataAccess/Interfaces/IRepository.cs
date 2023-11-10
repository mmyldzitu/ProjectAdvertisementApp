using AdvertisementApp.Common.Enums;
using AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> selector, OrderByType obtype = OrderByType.DESC);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> selector, OrderByType obtype);
        Task<T> FindAsync(object id);
        Task<T> FindByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQueryable();
        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);

    }
}
