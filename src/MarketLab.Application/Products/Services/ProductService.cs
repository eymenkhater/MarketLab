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
        }


    }
}