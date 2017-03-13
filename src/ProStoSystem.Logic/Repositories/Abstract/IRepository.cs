using System.Linq;

namespace ProStoSystem.Logic.Repositories.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetSpecified(Expression<Func<TEntity, bool>> prediction);

        IEnumerable<TEntity> GetAll();

        TEntity Get(Expression<Func<TEntity, bool>> prediction);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
