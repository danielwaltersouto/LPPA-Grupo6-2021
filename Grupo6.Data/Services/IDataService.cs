using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Grupo6.Data.Services
{
    public interface IDataService<T>
    {
        List<ValidationResult> ValidateModel(T model);
        List<T> Get(
            Expression<Func<T, bool>> WhereExpression = null,
            Func<IQueryable<T>> orderfunction = null,
            string includeModels = "");
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }

}