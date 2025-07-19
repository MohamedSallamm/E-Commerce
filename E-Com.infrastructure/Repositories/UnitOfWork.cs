using E_Com.Core.Interfaces;
using E_Com.infrastructure.Data;

namespace E_Com.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICategoryRepository CategoryRepository { get; }

        public IPhotoRepository PhotoRepository { get; }

        public IProductRepository ProductRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(context);
            PhotoRepository = new PhotoRepository(context);
            ProductRepository = new ProductRepository(context);
        }
    }
}
