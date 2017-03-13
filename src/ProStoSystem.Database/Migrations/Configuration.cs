namespace ProStoSystem.Database.Migrations
{
    using System.Configuration;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shared;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            SeedRoles(context);
            SeedBillTypes(context);
            SeedOwnerAccount(context);
            SeedCategories(context);
            SeedProducts(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists(AppStrings.OwnerRoleName))
            {
                var role = new IdentityRole { Name = AppStrings.OwnerRoleName };
                roleManager.Create(role);
            }
        }

        private void SeedOwnerAccount(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var ownerAccount = new ApplicationUser();
            var adminEmail = ConfigurationManager.AppSettings["adminEmail"];
            var adminPassword = ConfigurationManager.AppSettings["adminPassword"];

            ownerAccount.UserName = adminEmail;
            ownerAccount.Email = adminEmail;
            ownerAccount.EmailConfirmed = true;

            if (!context.Users.Any(u => u.UserName == ownerAccount.UserName))
            {
                var ownerResult = userManager.Create(ownerAccount, adminPassword);

                if (ownerResult.Succeeded)
                {
                    userManager.AddToRole(ownerAccount.Id, AppStrings.OwnerRoleName);
                    context.SaveChanges();
                }
            }
        }

        private void SeedBillTypes(ApplicationDbContext context)
        {
            var receipt = new BillType { Name = "Receipt" };
            var invoice = new BillType { Name = "Invoice" };

            if (!context.BillTypes.Any(bt => bt.Name == receipt.Name))
            {
                context.Set<BillType>().AddOrUpdate(receipt);
                context.SaveChanges();
            }

            if (!context.BillTypes.Any(bt => bt.Name == invoice.Name))
            {
                context.Set<BillType>().AddOrUpdate(invoice);
                context.SaveChanges();
            }
        }

        private void SeedCategories(ApplicationDbContext context)
        {
            for (int i = 1; i <= 5; i++)
            {
                var category = new Category
                {
                    Id = i,
                    Name = $"Category {i}"
                };

                if (!context.Categories.Any(c => c.Name == category.Name))
                {
                    context.Categories.AddOrUpdate(category);
                }
            }

            context.SaveChanges();
        }

        private void SeedProducts(ApplicationDbContext context)
        {
            for (int i = 1; i <= 20; i++)
            {
                var product = new Product
                {
                    Id = i,
                    Name = $"Product {i}",
                    Amount = i,
                    PurchasePrice = i + 2,
                    SellingPrice = i + 3,
                    CategoryId = i % 5 + 1
                };

                if (!context.Products.Any(p => p.Name == product.Name))
                {
                    context.Products.AddOrUpdate(product);
                    context.Categories.FirstOrDefault(c => c.Id == product.Category.Id).Products.Add(product);
                }
            }

            context.SaveChanges();
        }
    }
}
