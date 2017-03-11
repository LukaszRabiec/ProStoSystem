using System;

namespace ProStoSystem.Logic.UoW
{
    using System.Collections.Generic;
    using System.Linq;
    using Database;
    using Repositories.Abstract;
    using Repositories.Concrete;

    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            IRepository<TEntity> repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
