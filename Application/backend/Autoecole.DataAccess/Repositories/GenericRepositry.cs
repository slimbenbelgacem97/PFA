using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Abstract;
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Linq.Expressions;


namespace backend.Autoecole.DataAccess.Repositories
{
    public abstract class GenericRepositry<T> : IGenericRepositry<T> where T : class
    {
        protected readonly ModelContextV2 context;
        public GenericRepositry(ModelContextV2 context)
        {
            this.context = context;
        }
        public IQueryable<T> FindAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }
    }
}
