using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interfaces
{
    public interface IBaseRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(Tkey id);
        IList<TEntity> GetAll();
        TEntity GetById(Tkey id);


    }
}
