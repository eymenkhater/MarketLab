using AutoMapper;
using MarketLab.Application.Products.Models.Requests;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Application.Core.AutoMapper
{
    public class ProductAutomapperProfile : Profile
    {
        public ProductAutomapperProfile()
        {
            CreateMap<Product, SaveProductRequest>().ReverseMap();
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<ProductImage, SaveProductImageRequest>().ReverseMap();
        }
    }
}