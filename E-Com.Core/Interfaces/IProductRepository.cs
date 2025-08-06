using E_Com.Core.DTO;
using E_Com.Core.Entities.Product;
using E_Com.Core.Sharing;

namespace E_Com.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(ProductParams productParams);
        Task<bool> AddAsync(AddProductDTO addProductDTO);
        Task<bool> UpdateAsync(UpdateProductDTO UpdateProductDTO);
        Task DeleteAsync(Product product);
    }
}
