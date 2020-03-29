using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Core.Handlers;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Models;
using MarketLab.Application.Products.Models.Requests;
using MarketLab.Domain.Core.Interfaces.Data.BulkRepositories;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.Listings.Entities;

namespace MarketLab.Application.Products.Commands.ImportProducts
{
    public class ImportProductsCommandHandler : ResponseBaseHandler<bool>, ICommandHandler<ImportProductsCommand, bool>
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IListingRepository _listingRepository;
        private readonly IBulkProductRepository _bulkProductRepository;
        private readonly IBulkBrandRepository _bulkBrandRepository;
        private readonly IBulkListingRepository _bulkListingRepository;

        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public ImportProductsCommandHandler(
            IProductRepository productRepository,
            IBrandRepository brandRepository,
            IBulkBrandRepository bulkBrandRepository,
            IListingRepository listingRepository,
            IBulkProductRepository bulkProductRepository,
            IBulkListingRepository bulkListingRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _listingRepository = listingRepository;
            _bulkProductRepository = bulkProductRepository;
            _bulkBrandRepository = bulkBrandRepository;
            _bulkListingRepository = bulkListingRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<bool>> Handle(ImportProductsCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListAsync();
            var brands = await _brandRepository.ListAsync();
            var listings = await _listingRepository.ListAsync(request.ResourceId);
            var newResources = new List<Listing>();
            var newProductImages = new List<ProductImage>();
            var updateResources = new List<Listing>();
            var brandList = new List<Brand>();


            var requestBrands = request.Products.GroupBy(g => new { g.Brand?.Name });

            foreach (var requestBrand in requestBrands)
            {
                string brandName = requestBrand.Key?.Name ?? "Markasız";
                var brand = brands.FirstOrDefault(q => q.Name.ToLower().Trim() == brandName.ToLower().Trim()) ?? new Brand() { Name = brandName };
                brand.Products = new List<Product>();

                var requestProducts = requestBrand.GroupBy(q =>
                                                new { q.Name, q.Code, q.Listing.Stock, q.Listing.Price, q.Listing.IdentifierUrl });

                foreach (var requestProduct in requestProducts)
                {
                    var listing = listings.FirstOrDefault(q => q.IdentifierUrl.ToLower().Trim() == requestProduct.Key.IdentifierUrl.ToLower().Trim())
                                        ?? new Listing();

                    listing.ResourceId = request.ResourceId;
                    listing.Stock = requestProduct.Key.Stock;
                    listing.Price = requestProduct.Key.Price;
                    listing.IdentifierUrl = requestProduct.Key.IdentifierUrl;


                    if (listing.Id == 0)
                    {
                        var product = products.FirstOrDefault(q => q.Name.ToLower().Trim() == requestProduct.Key.Name.ToLower().Trim()) ?? new Product();

                        if (product.Id == 0)
                        {
                            product.Name = requestProduct.Key.Name;
                            product.Code = requestProduct.Key.Code;
                            product.BrandId = brand.Id;
                            product.Listings.Add(listing);
                            product.ProductImages = requestProduct.FirstOrDefault().ProductImages.Select(q => new ProductImage() { ImagePath = q.ImagePath }).ToList();
                            brand.Products.Add(product);
                        }
                        else
                        {
                            listing.ProductId = product.Id;
                            newResources.Add(listing);
                        }
                    }
                    else
                        updateResources.Add(listing);
                }

                brandList.Add(brand);
            }

            var newBrands = brandList.Where(q => q.Id == 0).ToList();
            var newProducts = brandList.Where(q => q.Id > 0).SelectMany(q => q.Products).ToList();

            await _bulkBrandRepository.BulkInsertAsync(newBrands);
            await _bulkProductRepository.BulkInsertAsync(newProducts);
            await _bulkListingRepository.BulkInsertAsync(newResources);
            await _bulkListingRepository.BulkUpdateAsync(updateResources);

            return OK();
        }
    }
}