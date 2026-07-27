using ECommerce.Api.DTOs;
using ECommerce.Api.Models;
using AutoMapper;



namespace ECommerce.Api.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}


