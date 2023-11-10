using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.DataAccess.Repositories;
using AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.UnitOfWork
{
   public class Uow:IUow
    {
        private readonly AdvertisementContext _advertisementContext;

        public Uow(AdvertisementContext advertisementContext)
        {
            _advertisementContext = advertisementContext;
        }
        public IRepository<T> GetRepository<T>() where T:BaseEntity
        {
            return new Repository<T>(_advertisementContext);
        }
        public async Task SaveChangesAsync()
        {
            await _advertisementContext.SaveChangesAsync();
        }
    }
}
