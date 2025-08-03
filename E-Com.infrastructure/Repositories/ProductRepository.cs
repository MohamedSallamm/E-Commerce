using AutoMapper;
using E_Com.Core.DTO;
using E_Com.Core.Entities.Product;
using E_Com.Core.Interfaces;
using E_Com.Core.Services;
using E_Com.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Com.infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IImageManageService _imageManageService;

        public ProductRepository(AppDbContext context, IMapper mapper, IImageManageService imageManageService) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _imageManageService = imageManageService;
        }

        public async Task<bool> AddAsync(AddProductDTO addProductDTO)
        {
            if (addProductDTO == null) return false;
            var product = _mapper.Map<Product>(addProductDTO);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            var imagePath = await _imageManageService.AddImageAsync(addProductDTO.Photo.ToList(), addProductDTO.Name);

            var photo = imagePath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = product.Id,
            }).ToList();
            _context.Photos.AddRange(photo);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> UpdateAsync(UpdateProductDTO UpdateProductDTO)
        {
            if (UpdateProductDTO == null) return false;
            var findProduct = await _context.Products.Include(m => m.Category)
                .Include(m => m.Photos)
                .FirstOrDefaultAsync(m => m.Id == UpdateProductDTO.Id);

            if (findProduct == null) return false;
            _mapper.Map(UpdateProductDTO, findProduct);

            var findphoto = _context.Photos.Where(m => m.ProductId == UpdateProductDTO.Id).ToList();
            foreach (var item in findphoto)
            {
                _imageManageService.DeleteImageAsync(item.ImageName);
            }
            _context.Photos.RemoveRange(findphoto);

            var ImagePath = await _imageManageService.AddImageAsync(UpdateProductDTO.Photo.ToList(), UpdateProductDTO.Name);
            var photos = ImagePath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = UpdateProductDTO.Id,
            }).ToList();
            _context.Photos.AddRange(photos);
            _context.SaveChanges();
            return true;
        }

        public async Task DeleteAsync(Product product)
        {
            var photo = await _context.Photos.Where(m => m.ProductId == product.Id).ToListAsync();
            foreach (var item in photo)
            {
                _imageManageService.DeleteImageAsync(item.ImageName);

            }
            _context.Photos.RemoveRange(photo);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
