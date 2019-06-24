using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Models;
using Type = DAL.Models.Type;

namespace BLL.Mappers
{
    public class BLLMappingsProfile : Profile
    {
        public BLLMappingsProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(m => m.Sizes, n => n.MapFrom(l => l.Sizes.ToList().AsEnumerable())).ReverseMap();
            CreateMap<Type, TypeDTO>().ReverseMap();
            CreateMap<Subtype, SubtypeDTO>().ReverseMap();
            CreateMap<Size, SizeDTO>().ReverseMap();
            CreateMap<TradeMark, TradeMarkDTO>().ReverseMap();
        }
    }
}
