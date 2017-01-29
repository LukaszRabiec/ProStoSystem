namespace ProStoSystem.Database.EntitiesConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    public class BillTypeConfiguration : EntityTypeConfiguration<BillType>
    {
        public BillTypeConfiguration()
        {
            Property(bt => bt.Name)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
