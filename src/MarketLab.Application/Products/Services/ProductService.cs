using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Brands.Models.Requests;
using MarketLab.Application.Products.Models.Requests;
using MarketLab.Domain.Core.Interfaces.Data.BulkRepositories;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Application.Products.Services
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IBulkProductRepository _bulkProductRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public ProductService(
            IProductRepository productRepository,
            IBrandRepository brandRepository,
            IResourceRepository resourceRepository,
            IBulkProductRepository bulkProductRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _resourceRepository = resourceRepository;
            _bulkProductRepository = bulkProductRepository;
            _mapper = mapper;
        }
        #endregion

        public Task<List<Product>> ListAsync()
        {
            throw new System.NotImplementedException();
        }
        public Task<Product> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public Task<Product> CreateAsync(CreateProductRequest request)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> UpdateAsync(UpdateProductRequest request)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public async Task ImportAsync(int resourceId, List<ImportProductRequest> requestProducts)
        {

            var products = await _productRepository.ListAsync();
            var brands = await _brandRepository.ListAsync();
            var resources = await _resourceRepository.ListAsync();

            var newBrands = new List<Brand>();
            var updateBrands = new List<Brand>();
            var newProducts = new List<Product>();
            var updateProducts = new List<Product>();

            var newProductResources = new List<ProductResource>();
            var updateProductResources = new List<ProductResource>();

            foreach (var item in requestProducts)
            {
                if (item.Brand != null)
                {
                    var brand = brands.FirstOrDefault(q => q.Name.ToLower() == item.Brand.Name.Trim().ToLower()) ?? new Brand();
                    brand = _mapper.Map<SaveBrandRequest, Brand>(item.Brand, brand);

                    if (brand.Id == 0)
                        newBrands.Add(brand);
                    else
                        updateBrands.Add(brand);
                }

                var product = products.FirstOrDefault(q => q.Name.ToLower() == item.Name.Trim().ToLower()) ?? new Product();
                var productResource = product.ProductResources.FirstOrDefault(q => q.ResourceId == resourceId && q.ProductId == product.Id);


                productResource = _mapper.Map<SaveProductResourceRequest, ProductResource>(item.ProductResource, productResource);
                productResource.ResourceId = resourceId;

                if (productResource.Id == 0)
                    newProductResources.Add(productResource);
                else
                    updateProductResources.Add(productResource);

                bool doesAvaliable = product.Id > 0;

                if (item.Brand != null)
                    product.Brand = brands.FirstOrDefault(q => q.Name.ToLower() == item.Brand.Name.Trim().ToLower());

                product = _mapper.Map<ImportProductRequest, Product>(item, product);
                product.Brand = _mapper.Map<Brand>(item.Brand);

                if (doesAvaliable)
                    updateProducts.Add(product);
                else
                    newProducts.Add(product);

            }

            await _bulkProductRepository.BulkInsertAsync(newProducts);

            await _bulkProductRepository.BulkUpdateAsync(updateProducts);

        }


    }
}