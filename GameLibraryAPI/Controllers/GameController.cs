using Microsoft.AspNetCore.Mvc;

namespace GameLibraryAPI.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
