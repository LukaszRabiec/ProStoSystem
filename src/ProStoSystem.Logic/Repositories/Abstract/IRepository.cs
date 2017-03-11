using System.Linq;

namespace ProStoSystem.Logic.Repositories.Abstract
{
    using System;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetSpecified(Expression<Func<TEntity, bool>> prediction);

        IQueryable<TEntity> GetAll();

        TEntity Get(Expression<Func<TEntity, bool>> prediction);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
