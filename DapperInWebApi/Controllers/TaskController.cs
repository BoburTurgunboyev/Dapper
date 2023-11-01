using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperInWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllInfos()
        {
            return RedirectPermanent("https://jsonplaceholder.typicode.com/posts");
        }
    }
}
