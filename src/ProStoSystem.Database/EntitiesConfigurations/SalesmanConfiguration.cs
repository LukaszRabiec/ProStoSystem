namespace ProStoSystem.Database.EntitiesConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    public class SalesmanConfiguration : EntityTypeConfiguration<Salesman>
    {
        public SalesmanConfiguration()
        {
            Property(s => s.FirstName)
                .IsRequired();
            Property(s => s.LastName)
                .IsRequired();
        }
    }
}
