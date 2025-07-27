﻿using AutoMapper;
using E_Com.Core.DTO;
using E_Com.Core.Entities.Product;

namespace E_Com.Api.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
        }
    }
}
