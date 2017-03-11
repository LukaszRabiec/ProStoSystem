namespace ProStoSystem.Logic.IoC
{
    using Autofac;
    using Database.Entities;
    using Repositories.Abstract;
    using Repositories.Concrete;
    using UoW;

    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            base.Load(builder);
        }
    }
}
