using System.Linq;

namespace ProStoSystem.Logic.Repositories.Concrete
{
    using System;
    using Abstract;
    using Database;
    using Database.Entities;
    using System.Data.Entity;

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
