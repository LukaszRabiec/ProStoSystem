namespace ProStoSystem.Logic.IoC
{
    using Autofac;
    using Database.Entities;
    using Repositories.Abstract;
    using Repositories.Concrete;

    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            base.Load(builder);
        }
    }
}
