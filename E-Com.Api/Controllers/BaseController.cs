using AutoMapper;
using E_Com.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Com.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _Work;
        protected readonly IMapper _Mapper;
        public BaseController(IUnitOfWork work, IMapper mapper)
        {
            _Work = work;
            _Mapper = mapper;

        }

    }
}
