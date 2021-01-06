using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Ganjeh.Api.Base
{
    [ApiController]
    [EnableCors("ApiCorsPolicy")]
    [Route("/api/v1/[area]/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}