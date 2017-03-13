namespace ProStoSystem.Database.EntitiesConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
        {
            HasRequired(od => od.BillType)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(od => od.BillTypeId);

            HasRequired(od => od.Salesman)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(od => od.SalesmanId);

            Property(od => od.Customer)
                .IsRequired();
            Property(od => od.OrderDate)
                .IsRequired();
        }
    }
}
