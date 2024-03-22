using Microsoft.AspNetCore.Mvc;

namespace SongRecommendation.UI.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
