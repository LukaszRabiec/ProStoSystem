namespace ProStoSystem.Logic.IoC
{
    using Autofac;
    using Database.Entities;
    using Repositories.Abstract;
    using Repositories.Concrete;
    using Services.Abstract;
    using Services.Concrete;

    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Services
            builder.RegisterType<ProductService>().As<IProductService>();

            // Repositories
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            base.Load(builder);
        }
    }
}
