using E_Com.Core.DTO;
using E_Com.Core.Entities.Product;

namespace E_Com.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> AddAsync(AddProductDTO addProductDTO);
        Task<bool> UpdateAsync(UpdateProductDTO UpdateProductDTO);
        Task DeleteAsync(Product product);
    }
}
