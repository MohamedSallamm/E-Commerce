using AutoMapper;
using E_Com.Core.Interfaces;
using E_Com.Core.Services;
using E_Com.infrastructure.Data;

namespace E_Com.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageManageService _imageManageService;
        public ICategoryRepository CategoryRepository { get; }

        public IPhotoRepository PhotoRepository { get; }

        public IProductRepository ProductRepository { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManageService imageManageService)

        {
            _context = context;
            _mapper = mapper;
            _imageManageService = imageManageService;

            CategoryRepository = new CategoryRepository(_context);
            PhotoRepository = new PhotoRepository(_context);
            ProductRepository = new ProductRepository(_context, _mapper, _imageManageService);
        }
    }
}
