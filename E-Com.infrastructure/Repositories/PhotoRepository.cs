using E_Com.Core.Entities.Product;
using E_Com.Core.Interfaces;
using E_Com.infrastructure.Data;

namespace E_Com.infrastructure.Repositories
{
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
