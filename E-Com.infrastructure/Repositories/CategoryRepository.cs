using E_Com.Core.Entities.Product;
using E_Com.Core.Interfaces;
using E_Com.infrastructure.Data;

namespace E_Com.infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
