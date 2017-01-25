namespace ProStoSystem.Database.EntitiesConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    public class SalesmanEntityConfiguration : EntityTypeConfiguration<Salesman>
    {
        public SalesmanEntityConfiguration()
        {
            Property(s => s.FirstName).IsRequired();
            Property(s => s.LastName).IsRequired();
        }
    }
}
