using AutoMapper;
using E_Com.Api.Helper;
using E_Com.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Com.Api.Controllers
{

    public class BugController : BaseController
    {
        public BugController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("NotFound")]
        public async Task<ActionResult> GetNotFound()
        {
            var category = await _Work.CategoryRepository.GetByIdAsync(100000000);
            if (category == null) return NotFound(new ResponseApi(404));
            return Ok(category);
        }

        [HttpGet("ServerError")]
        public async Task<ActionResult> GetServerError()
        {
            var category = await _Work.CategoryRepository.GetByIdAsync(10);
            string name = category.Name = "InternalServerError";
            return Ok(category);
        }
        [HttpGet("BadRequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            if (id <= 0) return BadRequest(new ResponseApi(400, "Id must be greater than zero"));
            return Ok();
        }
        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ResponseApi(400, "This is a bad request resources"));
        }
    }
}
