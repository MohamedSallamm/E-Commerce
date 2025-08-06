using AutoMapper;
using E_Com.Api.Helper;
using E_Com.Core.DTO;
using E_Com.Core.Interfaces;
using E_Com.Core.Sharing;
using Microsoft.AspNetCore.Mvc;

namespace E_Com.Api.Controllers
{

    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] ProductParams productParams)
        {
            try
            {
                var Products = await _Work.ProductRepository.GetAllAsync(productParams);
                var totalCount = await _Work.ProductRepository.CountAsync();
                return Ok(new Pagination<ProductDTO>(productParams.PageNumber, productParams.PageSize, totalCount, data: Products));
            }

            catch (Exception ex)
            {
                return StatusCode(500, new ResponseApi(500, ex.Message));
            }
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _Work.ProductRepository.GetByIdAsync(id, x => x.Category, x => x.Photos);
                var result = _Mapper.Map<ProductDTO>(product);
                if (product is null)
                    return NotFound(new ResponseApi(404));
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDTO addProductDTO)
        {
            try
            {
                await _Work.ProductRepository.AddAsync(addProductDTO);
                return Ok(new ResponseApi(200, "Product added successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseApi(400, ex.Message));
            }

        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDTO updateProductDTO)
        {
            try
            {
                await _Work.ProductRepository.UpdateAsync(updateProductDTO);
                return Ok(new ResponseApi(200, "Product updated successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseApi(400, ex.Message));
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _Work.ProductRepository.GetByIdAsync(id, x => x.Photos, y => y.Category);
                await _Work.ProductRepository.DeleteAsync(product);
                return Ok(new ResponseApi(200, "Product deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseApi(400, ex.Message));
            }

        }
    }
}
