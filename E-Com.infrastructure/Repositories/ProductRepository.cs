using E_Com.Core.Entities.Product;
using E_Com.Core.Interfaces;
using E_Com.infrastructure.Data;

namespace E_Com.infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
