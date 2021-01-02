using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Ganjeh.Api.Base
{
    [ApiController]
    [Authorize]
    [EnableCors("ApiCorsPolicy")]
    [Route("/api/[area]/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}