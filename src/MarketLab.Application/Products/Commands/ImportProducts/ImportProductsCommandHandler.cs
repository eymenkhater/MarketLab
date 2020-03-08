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
        private readonly IBulkProductResourceRepository _bulkProductResourceRepository;

        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public ImportProductsCommandHandler(
            IProductRepository productRepository,
            IBrandRepository brandRepository,
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
            var updateResources = new List<ProductResource>();
            var newProducts = new List<Product>();

            foreach (var item in request.Products)
            {
                var productResource = productResources.FirstOrDefault(q => q.IdentifierUrl.ToLower().Trim() == item.ProductResource.IdentifierUrl.ToLower().Trim());
                productResource = _mapper.Map<SaveProductResourceRequest, ProductResource>(item.ProductResource, productResource);

                if (productResource.Id == 0)
                {
                    productResource.ResourceId = request.ResourceId;

                    var product = products.FirstOrDefault(q => q.Name.ToLower().Trim() == item.Name.ToLower().Trim());

                    if (product == null)
                    {
                        product = _mapper.Map<Product>(item);
                        product.ProductResources.Add(productResource);

                        if (product.Brand != null)
                        {
                            var brand = brands.FirstOrDefault(q => q.Name.ToLower().Trim() == product.Brand.Name.ToLower().Trim());
                            if (brand != null)
                            {
                                product.BrandId = brand.Id;
                                product.Brand = null;
                            }
                        }

                        newProducts.Add(product);
                    }
                    else
                        newResources.Add(productResource);
                }
                else
                    updateResources.Add(productResource);
            }

            await _bulkProductRepository.BulkInsertAsync(newProducts);
            await _bulkProductResourceRepository.BulkInsertAsync(newResources);
            await _bulkProductResourceRepository.BulkUpdateAsync(updateResources);

            return OK();
        }
    }
}