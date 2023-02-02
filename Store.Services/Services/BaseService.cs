using FluentValidation;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;


        public BaseService (IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity> 
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            return obj;
        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj,Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IList<TEntity> GetAll() => _baseRepository.GetAll();

        public TEntity GetById(int id) => _baseRepository.GetById(id);

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null) throw new Exception("Register could not be found");

            validator.ValidateAndThrow(obj);
        }

        
    }
}
