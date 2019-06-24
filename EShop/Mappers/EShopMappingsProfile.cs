﻿using AutoMapper;
using BLL.DTO;
using EShop.Models;
using EShop.Models.Products;

namespace EShop.Mappers
{
    public class EShopMappingsProfile : Profile
    {
        public EShopMappingsProfile()
        {
            CreateMap<ProductDTO, ProductVM>().ReverseMap();
            CreateMap<ProductDTO, LandingVM>().ReverseMap();

            CreateMap<TypeDTO, TypeVM>().ReverseMap();
            CreateMap<SubtypeDTO, SubtypeVM>().ReverseMap();
            CreateMap<SizeDTO, SizeVM>().ReverseMap();
            CreateMap<TradeMarkDTO, TradeMarkVM>().ReverseMap();
        }
    }
}