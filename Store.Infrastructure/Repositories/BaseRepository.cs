using Microsoft.EntityFrameworkCore.Infrastructure;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repositories
{
    public class BaseRepository<TEntity, Tkey> : IBaseRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        protected readonly ApplicationDataContext _applicationDataContext;

        public BaseRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }

        public void Add(TEntity obj) 
        {
            _applicationDataContext.Set<TEntity>().Add(obj);
            _applicationDataContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _applicationDataContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDataContext.SaveChanges();
        }

        public void Delete(Tkey id)
        {
            _applicationDataContext.Set<TEntity>().Remove(GetById(id));
            _applicationDataContext.SaveChanges();
        }

        public IList<TEntity> GetAll() =>
            _applicationDataContext.Set<TEntity>().ToList();

        public TEntity GetById(Tkey id) =>
            _applicationDataContext.Set<TEntity>().Find(id);

        public async Task<int> SaveChangesAsync()
        {
            var item = await _applicationDataContext.SaveChangesAsync().ConfigureAwait(false);
            return item;
        }
    }
}

