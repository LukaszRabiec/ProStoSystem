namespace ProStoSystem.Logic.Repositories.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Xml.Serialization;
    using Database.Entities;

    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetSpecified(Expression<Func<TEntity, bool>> prediction);

        IEnumerable<TEntity> GetAll();

        TEntity Get(Expression<Func<TEntity, bool>> prediction);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void SaveChanges();
    }
}
