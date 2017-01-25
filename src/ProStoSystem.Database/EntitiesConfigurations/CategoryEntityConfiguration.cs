namespace ProStoSystem.Database.EntitiesConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    public class CategoryEntityConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryEntityConfiguration()
        {
            Property(c => c.Name).IsRequired();
        }
    }
}
