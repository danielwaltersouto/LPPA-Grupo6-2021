using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Grupo6.Data.Services
{
    public class BaseDataService<T> : IDataService<T> where T : Entities.Models.IdentityBase, new()
    {

        protected MarketDbContext marketContext;

        public BaseDataService()
        {
            this.marketContext = new MarketDbContext();
        }

        public T Create(T entity)
        {
            marketContext.Set<T>().Add(entity);
            marketContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            marketContext.Set<T>().Remove(entity);
            marketContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunction = null, string includeModels = "")
        {
            IQueryable<T> query = marketContext.Set<T>();

            if (whereExpression != null)
                query = query.Where(whereExpression);

            var entity = includeModels.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            query = entity.Aggregate(query, (current, model) => current.Include(model));

            if (orderFunction != null)
                query = orderFunction(query);

            return query.ToList();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public List<ValidationResult> ValidateModel(T model)
        {
            throw new NotImplementedException();
        }
    }

}
