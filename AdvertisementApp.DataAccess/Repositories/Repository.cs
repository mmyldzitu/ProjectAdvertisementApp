using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Repositories
{
    public class Repository<T>: IRepository<T> where T: BaseEntity
    {
        private readonly AdvertisementContext _advertisementContext;

        public Repository(AdvertisementContext advertisementContext)
        {
            _advertisementContext = advertisementContext;
        }

        //Tüm veriyi getirme
        public async Task<List<T>> GetAllAsync()
        {
            return await _advertisementContext.Set<T>().AsNoTracking().ToListAsync();
        }
        //filtre ile getirme
        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter)
        {
            return await _advertisementContext.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        //sıralayarak getirme
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T,TKey>> selector, OrderByType obtype=OrderByType.DESC )
        {
            return obtype == OrderByType.ASC ? await _advertisementContext.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() : await _advertisementContext.Set<T>().OrderByDescending(selector).ToListAsync();
        }
        //Hem filtreleyerek hem sıralayarak getirme
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T,bool>> filter, Expression<Func<T,TKey>> selector, OrderByType obtype=OrderByType.DESC)
        {
            return obtype == OrderByType.ASC ? await _advertisementContext.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync(): await _advertisementContext.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
        }
        //idye göre bulma
        public async Task<T> FindAsync(object id)
        {
            return await _advertisementContext.Set<T>().FindAsync(id);
        }
        //herhangi bir filtreye göre bulma
        public async Task<T> FindByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking=false)
        {
            return !asNoTracking ? await _advertisementContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) : await _advertisementContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        //Direkt olarak veri tabanı üzerinde sorgulamak için
        public IQueryable<T> GetQueryable()
        {
            return _advertisementContext.Set<T>().AsQueryable();
        }
        //kaldırma işlemi
        public void Remove(T entity)
        {
            _advertisementContext.Set<T>().Remove(entity);
        }
        //ekleme işlemi
        public async Task CreateAsync (T entity)
        {
            await _advertisementContext.Set<T>().AddAsync(entity);
        }
        //güncelleme işlemi
        public void  Update(T entity, T unchanged)
        {
             _advertisementContext.Entry(unchanged).CurrentValues.SetValues(entity);
        }

    }
}
