using AutoMapper;
using MarketLab.Application.Brands.Models.Requests;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Listings.Models.Responses;
using MarketLab.Application.Products.Dtos;
using MarketLab.Application.Products.Models.Requests;
using MarketLab.Application.SearchLogs.Commands.Base;
using MarketLab.Application.SearchLogs.Commands.CreateSearcLog;
using MarketLab.Application.Sliders.Commands.Base;
using MarketLab.Application.Sliders.Commands.CreateSlider;
using MarketLab.Domain.Listings.Entities;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.Resources.Entities;
using MarketLab.Domain.SearchLogs.Entities;
using MarketLab.Domain.ShoppingLists.Entities;
using MarketLab.Domain.Sliders.Entities;

namespace MarketLab.Application.Core.AutoMapper
{
    public class ProductAutomapperProfile : Profile
    {
        public ProductAutomapperProfile()
        {
            #region Products
            CreateMap<Product, SaveProductRequest>().ReverseMap();
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<Product, ImportProductRequest>().ReverseMap();
            CreateMap<Product, FeaturedListingsResponse>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductSearchDto>().ReverseMap();

            CreateMap<ProductImage, SaveProductImageRequest>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            #endregion

            #region Listings
            CreateMap<Listing, SaveListingRequest>().ReverseMap();
            CreateMap<Listing, ListingDto>().ReverseMap();
            CreateMap<Listing, SelectedProductListingsResponse>().ReverseMap();
            #endregion

            #region Resources
            CreateMap<Resource, ResourceDto>().ReverseMap();
            #endregion

            #region ShoppingListItems
            CreateMap<ShoppingListItem, ShoppingListItemDto>().ReverseMap();
            #endregion

            #region Brands
            CreateMap<Brand, SaveBrandRequest>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            #endregion

            #region Sliders
            CreateMap<Slider, SaveSliderCommand>().ReverseMap();
            CreateMap<Slider, CreateSliderCommand>().ReverseMap();
            CreateMap<Slider, SliderDto>().ReverseMap();
            #endregion

            #region SearchLogs
            CreateMap<SearchLog, SaveSearchLogCommand>().ReverseMap();
            CreateMap<SearchLog, CreateSearchLogCommand>().ReverseMap();
            #endregion

        }
    }
}