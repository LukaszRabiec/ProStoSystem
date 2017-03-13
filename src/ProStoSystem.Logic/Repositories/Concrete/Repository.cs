using System;
using System.Linq;

namespace ProStoSystem.Logic.Repositories.Concrete
{
    using System.Collections.Generic;
    using Abstract;
    using Database;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using Database.Entities;

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _context;
        private IDbSet<TEntity> _dbSet;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetSpecified(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
