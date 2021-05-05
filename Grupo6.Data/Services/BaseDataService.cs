using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Grupo6.Data.Services
{
    public class BaseDataService<T> : IDataService<T> where T : Entities.Models.IdentityBase, new()
    {

        protected MarketDbContext Db;

        public BaseDataService()
        {
            this.Db = new MarketDbContext();
        }

        public T Create(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
            return entity;
        }

        public void delete(T entity)
        {
            Db.Set<T>().Remove(entity);
            Db.SaveChanges();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> get(Expression<Func<T, bool>> WhereExpression = null, Func<IQueryable<T>> orderfunction = null, string includeModels = "")
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(T entity)
        {
            throw new NotImplementedException();
        }

        public List<ValidationResult> ValidateModel(T model)
        {
            throw new NotImplementedException();
        }
    }

}
