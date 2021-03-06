namespace ProStoSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillType",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 64),
                    IsArchived = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderDetail",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Customer = c.String(nullable: false),
                    OrderDate = c.DateTimeOffset(nullable: false, precision: 7),
                    Comment = c.String(),
                    Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    BillTypeId = c.Int(nullable: false),
                    SalesmanId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillType", t => t.BillTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Salesman", t => t.SalesmanId, cascadeDelete: true)
                .Index(t => t.BillTypeId)
                .Index(t => t.SalesmanId);

            CreateTable(
                "dbo.Product",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 128),
                    SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Amount = c.Int(nullable: false),
                    IsArchived = c.Boolean(nullable: false),
                    CategoryId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Category",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 64),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Salesman",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    IsArchived = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.ProductOrder",
                c => new
                {
                    ProductId = c.Int(nullable: false),
                    OrderDetailId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ProductId, t.OrderDetailId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.OrderDetail", t => t.OrderDetailId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderDetailId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderDetail", "SalesmanId", "dbo.Salesman");
            DropForeignKey("dbo.ProductOrder", "OrderDetailId", "dbo.OrderDetail");
            DropForeignKey("dbo.ProductOrder", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.OrderDetail", "BillTypeId", "dbo.BillType");
            DropIndex("dbo.ProductOrder", new[] { "OrderDetailId" });
            DropIndex("dbo.ProductOrder", new[] { "ProductId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.OrderDetail", new[] { "SalesmanId" });
            DropIndex("dbo.OrderDetail", new[] { "BillTypeId" });
            DropTable("dbo.ProductOrder");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Salesman");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.BillType");
        }
    }
}
