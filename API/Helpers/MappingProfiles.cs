using API.DTO;
using Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductResponseDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            /*
             * What this code means:
             * ForMember - we are specifying destination field name that we want to map to from source.
             * In this case, d.ProductBrand basically says ProductsResponseDto.ProductBrand. That where MapFrom field will be mapped.
             * 
             * MapFrom - here we are specifying source of the field. 
             * s.ProductBrand.Name can be read as  Product.ProductBrand.Name, 
             * which will be mapped to ProductsResponseDto.ProductBrand.
             * 
             */
        }
    }
}
