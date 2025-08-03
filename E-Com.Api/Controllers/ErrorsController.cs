using E_Com.Api.Helper;
using Microsoft.AspNetCore.Mvc;

namespace E_Com.Api.Controllers
{
    [Route("api/Errors/{statusCode}")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public ActionResult HandleErrors(int statusCode)
        {
            return new ObjectResult(new ResponseApi(statusCode));
        }
    }
}
