using Autofac;
using BLL.Interfaces;
using BLL.Services;
using DAL.DI;

namespace BLL.DI
{
    public class BLLDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DALDIModule>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<TradeMarkService>().As<ITradeMarkService>();
            builder.RegisterType<SizeService>().As<ISizeService>();
        }
    }
}
