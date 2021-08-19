using Microsoft.AspNetCore.Mvc;

namespace Esourcing.UI.Controllers
{
    public class AuctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
