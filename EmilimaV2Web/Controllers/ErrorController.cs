using Microsoft.AspNetCore.Mvc;

namespace EmilimaV2Web.Controllers
{
    public class ErrorController : Controller
    {
		public IActionResult Error401()
		{
			return View();
		}

		public IActionResult Error403()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
