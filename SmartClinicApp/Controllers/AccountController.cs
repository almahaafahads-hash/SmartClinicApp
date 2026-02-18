using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClinicApp.Controllers
{
    public class AccountController : Controller
    {
        // ================= LOGIN =================
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // مستخدم تجريبي
            if (email == "admin@test.com" && password == "1234")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email)
                };

                var identity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                );

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal
                );

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "بيانات الدخول غير صحيحة";
            return View();
        }

        // ================= REGISTER =================
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string fullName, string email, string password)
        {
            // حالياً بدون تخزين قاعدة بيانات
            TempData["Msg"] = "تم إنشاء الحساب (تجريبي) ✅";
            return RedirectToAction("Login");
        }

        // ================= LOGOUT =================
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}