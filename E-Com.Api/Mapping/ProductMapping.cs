using AutoMapper;
using E_Com.Core.DTO;
using E_Com.Core.Entities.Product;

namespace E_Com.Api.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.CategoryName, op => op.MapFrom(src => src.Category.Name)) // Assuming Category has a Name property
                .ReverseMap();

            CreateMap<Photo, PhotoDTO>().ReverseMap();
        }
    }
}
