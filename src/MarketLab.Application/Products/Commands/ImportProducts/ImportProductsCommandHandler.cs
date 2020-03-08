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

namespace MarketLab.Application.Products.Commands.ImportProducts
{
    public class ImportProductsCommandHandler : ResponseBaseHandler<bool>, ICommandHandler<ImportProductsCommand, bool>
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductResourceRepository _productResourceRepository;
        private readonly IBulkProductRepository _bulkProductRepository;
        private readonly IBulkBrandRepository _bulkBrandRepository;
        private readonly IBulkProductResourceRepository _bulkProductResourceRepository;

        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public ImportProductsCommandHandler(
            IProductRepository productRepository,
            IBrandRepository brandRepository,
            IBulkBrandRepository bulkBrandRepository,
            IProductResourceRepository productResourceRepository,
            IBulkProductRepository bulkProductRepository,
            IBulkProductResourceRepository bulkProductResourceRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _productResourceRepository = productResourceRepository;
            _bulkProductRepository = bulkProductRepository;
            _bulkBrandRepository = bulkBrandRepository;
            _bulkProductResourceRepository = bulkProductResourceRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<bool>> Handle(ImportProductsCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListAsync();
            var brands = await _brandRepository.ListAsync();
            var productResources = await _productResourceRepository.ListAsync(request.ResourceId);
            var newResources = new List<ProductResource>();
            var newProductImages = new List<ProductImage>();
            var updateResources = new List<ProductResource>();
            var brandList = new List<Brand>();


            var requestBrands = request.Products.GroupBy(g => new { g.Brand?.Name });

            foreach (var requestBrand in requestBrands)
            {
                string brandName = requestBrand.Key?.Name ?? "Markasız";
                var brand = brands.FirstOrDefault(q => q.Name.ToLower().Trim() == brandName.ToLower().Trim()) ?? new Brand() { Name = brandName };
                brand.Products = new List<Product>();

                var requestProducts = requestBrand.GroupBy(q =>
                                                new { q.Name, q.Code, q.ProductResource.Stock, q.ProductResource.Price, q.ProductResource.IdentifierUrl });

                foreach (var requestProduct in requestProducts)
                {
                    var productResource = productResources.FirstOrDefault(q => q.IdentifierUrl.ToLower().Trim() == requestProduct.Key.IdentifierUrl.ToLower().Trim())
                                        ?? new ProductResource();

                    productResource.ResourceId = request.ResourceId;
                    productResource.Stock = requestProduct.Key.Stock;
                    productResource.Price = requestProduct.Key.Price;
                    productResource.IdentifierUrl = requestProduct.Key.IdentifierUrl;


                    if (productResource.Id == 0)
                    {
                        var product = products.FirstOrDefault(q => q.Name.ToLower().Trim() == requestProduct.Key.Name.ToLower().Trim()) ?? new Product();

                        if (product.Id == 0)
                        {
                            product.Name = requestProduct.Key.Name;
                            product.Code = requestProduct.Key.Code;
                            product.BrandId = brand.Id;
                            product.ProductResources.Add(productResource);
                            product.ProductImages = requestProduct.FirstOrDefault().ProductImages.Select(q => new ProductImage() { ImagePath = q.ImagePath }).ToList();
                            brand.Products.Add(product);
                        }
                        else
                        {
                            productResource.ProductId = product.Id;
                            newResources.Add(productResource);
                        }
                    }
                    else
                        updateResources.Add(productResource);
                }

                brandList.Add(brand);
            }

            var newBrands = brandList.Where(q => q.Id == 0).ToList();
            var newProducts = brandList.Where(q => q.Id > 0).SelectMany(q => q.Products).ToList();

            await _bulkBrandRepository.BulkInsertAsync(newBrands);
            await _bulkProductRepository.BulkInsertAsync(newProducts);
            await _bulkProductResourceRepository.BulkInsertAsync(newResources);
            await _bulkProductResourceRepository.BulkUpdateAsync(updateResources);

            return OK();
        }
    }
}