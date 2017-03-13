namespace ProStoSystem.Logic.Repositories.Concrete
{
    using Abstract;
    using Database;
    using Database.Entities;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
