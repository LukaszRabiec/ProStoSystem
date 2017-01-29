using System.Linq;

namespace ProStoSystem.Logic.Repositories.Concrete
{
    using Abstract;
    using Database;
    using Database.Entities;
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product Get(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products.AsNoTracking();
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            var dbProduct = _context.Products.Find(entity);
            dbProduct.Name = entity.Name;
            dbProduct.Amount = entity.Amount;
            dbProduct.Category = entity.Category;
            dbProduct.PurchasePrice = entity.PurchasePrice;
            dbProduct.SellingPrice = entity.SellingPrice;
            dbProduct.OrderDetails = entity.OrderDetails;

            _context.SaveChanges();
        }

        public void Remove(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }
    }
}
