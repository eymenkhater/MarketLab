using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IBulkProductRepository _bulkProductRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public ProductService(
            IProductRepository productRepository,
            IBulkProductRepository bulkProductRepository,
            IBrandRepository brandRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _bulkProductRepository = bulkProductRepository;
            _brandRepository = brandRepository;
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

        public async Task ImportAsync(List<ImportProductRequest> requestProducts)
        {
            var products = await _productRepository.ListAsync();
            var brands = await _brandRepository.ListAsync();

            var newProducts = new List<Product>();
            var updateProducts = new List<Product>();

            foreach (var item in requestProducts)
            {
                var product = products.FirstOrDefault(q => q.Name.ToLower() == item.Name.Trim().ToLower());

                if (!string.IsNullOrEmpty(item.BrandName))
                    product.Brand = brands.FirstOrDefault(q => q.Name.ToLower() == item.BrandName.Trim().ToLower());

                product.Brand = product.Brand ?? new Brand() { Name = item.BrandName };

                bool doesAvaliable = product != null;
                product = product ?? new Product();

                product = _mapper.Map<ImportProductRequest, Product>(item, product);

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