using AutoMapper;
using MarketLab.Application.Brands.Models.Requests;
using MarketLab.Application.Core.Dtos;
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
            CreateMap<Product, ImportProductRequest>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<ProductImage, SaveProductImageRequest>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<ProductResource, SaveProductResourceRequest>().ReverseMap();
            CreateMap<ProductResource, ProductResourceDto>().ReverseMap();

            CreateMap<Brand, SaveBrandRequest>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();

        }
    }
}