using AutoMapper;
using E_Com.Api.Helper;
using E_Com.Core.DTO;
using E_Com.Core.Entities.Product;
using E_Com.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Com.Api.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork work, IMapper _mapper) : base(work, _mapper)
        {
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _Work.CategoryRepository.GetAllAsync();
                if (categories is null)
                    return BadRequest(new ResponseApi(400));
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _Work.CategoryRepository.GetByIdAsync(id);
                if (category is null)
                    return BadRequest(new ResponseApi(400, message: $"id {id} Not found"));
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CategoryDTO categoryDTO)
        {
            try
            {
                var category = _Mapper.Map<Category>(categoryDTO);
                await _Work.CategoryRepository.AddAsync(category);
                return Ok(new ResponseApi(200, message: "Succefully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> Update(UpdateCategoryDTO updateCategoryDTO)
        {
            try
            {
                var category = new Category()
                {
                    Id = updateCategoryDTO.Id,
                    Name = updateCategoryDTO.Name,
                    Description = updateCategoryDTO.Description,
                };
                await _Work.CategoryRepository.UpdateAsync(category);
                return Ok(new ResponseApi(200, message: "Succefully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Work.CategoryRepository.DeleteAsync(id);
                return Ok(new ResponseApi(200, message: "Has been deleted"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
