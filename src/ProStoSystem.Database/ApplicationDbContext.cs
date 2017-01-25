namespace ProStoSystem.Database
{
    using System.Data.Entity;
    using Entities;
    using EntitiesConfigurations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<BillType> BillTypes { get; set; }
        public DbSet<Salesman> Salesmans { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ProductEntityConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailEntityConfiguration());
            modelBuilder.Configurations.Add(new CategoryEntityConfiguration());
            modelBuilder.Configurations.Add(new SalesmanEntityConfiguration());
            modelBuilder.Configurations.Add(new BillTypeEntityConfiguration());
        }
    }
}
