using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using backend.Data;


namespace backend.Repositries
{
    public abstract class RepositryBase<T> : IRepositryBase<T> where T : class
    {
        protected readonly Model context;
        public RepositryBase(Model context)
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
        public void Update (T entity)
        {
            this.context.Set<T>().Update(entity);
        }
        public void Delete (T entity)
        {
            this.context.Set<T>().Remove(entity);
        }
    }
}
