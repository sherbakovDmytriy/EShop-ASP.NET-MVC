using System.Data.Entity;
using Autofac;
using DAL.Data;

namespace DAL.DI
{
    public class DALDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => (DbContext)new ApplicationDbContext()).As<DbContext>();

            builder
                .RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
