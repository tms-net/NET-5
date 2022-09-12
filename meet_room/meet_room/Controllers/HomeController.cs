using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace meet_room.Controllers;

public class HomeController: Controller
{
    [Authorize]
    [HttpGet]
    public IActionResult Account()
    {
        return Ok(HttpContext.User.Identity.Name);
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        // Normally Identity handles sign in, but you can do it directly
        if (ValidateLogin(userName, password))
        {
            // Login login
            var claims = new List<Claim>
            {
                new Claim("user", userName),
                new Claim("role", "Member"),
                new Claim(ClaimTypes.Authentication, "password")
            };

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        claims, "Cookies", "user", "role")));

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/app");
            }
        }

        return View();


        // HTTP/1.1 302 Redirect
        // Location: /app
        return Redirect("/app");
    }

    private bool ValidateLogin(string userName, string password)
    {
        // Проверка в базе

        return true;
    }
}