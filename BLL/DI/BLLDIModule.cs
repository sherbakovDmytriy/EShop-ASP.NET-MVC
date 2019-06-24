using Autofac;
using DAL.DI;

namespace BLL.DI
{
    public class BLLDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DALDIModule>();
            builder.RegisterType<ProductService>().As<IProductService>();
        }
    }
}
