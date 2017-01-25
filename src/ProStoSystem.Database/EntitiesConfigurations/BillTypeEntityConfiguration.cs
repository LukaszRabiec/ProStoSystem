namespace ProStoSystem.Database.EntitiesConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    public class BillTypeEntityConfiguration : EntityTypeConfiguration<BillType>
    {
        public BillTypeEntityConfiguration()
        {
            Property(bt => bt.Name).IsRequired();
        }
    }
}
