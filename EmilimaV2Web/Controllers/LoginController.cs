using EmilimaV2Web.Models;
using EmilimaV2Web.Models.AccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace EmilimaV2Web.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly EmilimaContext _context;

        public LoginController(
            ILogger<LoginController> logger,
            EmilimaContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            _logger.Log(LogLevel.Information, "--- {0}.{1} ---", GetType(), MethodBase.GetCurrentMethod() ?? null);

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.Log(LogLevel.Information, "--- {0}.{1} ---", GetType(), MethodBase.GetCurrentMethod() ?? null);

            if (ModelState.IsValid)
            {
                var user = await AuthenticateUser(model.UserName, model.Password);

                if (user == null)
                {
                    return View("Index");
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {

                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                _logger.Log(LogLevel.Information, "--- {0}.{1} Login successfully ---", GetType(), MethodBase.GetCurrentMethod() ?? null);

                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }

        private async Task<User?> AuthenticateUser(string userName, string password)
        {
            if (userName == null || _context.Users == null)
            {
                return null;
            }

            var user = await _context.Users
                .Include(u => u.Photo)
                .Include(u => u.Position)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Username == userName && m.Password == password);
            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
