using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Application.Products.Dtos.Requests;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Application.Products.Services
{
    public interface IProductService
    {
        Task<List<Product>> ListAsync();
        Task<Product> GetAsync(int id);
        Task<Product> CreateAsync(CreateProductRequest request);
        Task<bool> UpdateAsync(UpdateProductRequest request);
        Task<bool> DeleteAsync(int id);
        Task ImportAsync(ImportProductsRequest request);
    }
}