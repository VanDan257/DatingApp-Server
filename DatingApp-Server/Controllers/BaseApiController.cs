using AppChat_Server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AppChat_Server.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
