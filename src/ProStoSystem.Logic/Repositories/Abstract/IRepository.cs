using System.Linq;

namespace ProStoSystem.Logic.Repositories.Abstract
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity Get(TKey id);
        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entityt);
    }
}
