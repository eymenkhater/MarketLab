using AutoMapper;
using MarketLab.Application.Products.Dtos.Requests;
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
            CreateMap<ProductDimension, SaveProductDimensionRequest>().ReverseMap();
            CreateMap<ProductImage, SaveProductImageRequest>().ReverseMap();
        }
    }
}