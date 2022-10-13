using Microsoft.AspNetCore.Mvc;

namespace EmilimaV2Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
