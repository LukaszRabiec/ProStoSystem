namespace ProStoSystem.Database.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shared;

    internal sealed class Configuration : DbMigrationsConfiguration<ProStoSystem.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProStoSystem.Database.ApplicationDbContext context)
        {
            SeedRoles(context);
            SeedBillTypes(context);
            SeedOwnerAccount(context);
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

        // I know it's not the best solution. It's temporary.
        // If you get here and you may have some ideas for creating
        // owner account from app without registration, send me message :)
        private void SeedOwnerAccount(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var ownerAccount = new ApplicationUser();
            ownerAccount.UserName = "owner.pssystem@gmail.com";
            ownerAccount.Email = "owner.pssystem@gmail.com";
            ownerAccount.EmailConfirmed = true;

            if (!context.Users.Any(u => u.UserName == ownerAccount.UserName))
            {
                var ownerResult = userManager.Create(ownerAccount, "Zxc!23");

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
    }
}
