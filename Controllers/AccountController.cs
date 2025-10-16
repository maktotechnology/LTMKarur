using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LTMKarur.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated ?? false)
            return RedirectToAction("Index", "Dashboard");

        return View();
    }

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Login(string username, string password)
{
    if (username == "admin" && password == "admin")
    {
        var claims = new List<Claim> { new(ClaimTypes.Name, username) };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = true });

        // 👇 THIS IS THE REDIRECT LINE
        return RedirectToAction("Index", "Dashboard");
    }

    ViewBag.Error = "Invalid username or password.";
    return View();
}

    // Primary logout (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        _logger.LogInformation("Logout called. User: {User}", User.Identity?.Name ?? "<none>");
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        Response.Cookies.Delete(".AspNetCore.Cookies"); // attempt to clear cookie
        _logger.LogInformation("Sign out complete. Redirecting to Login.");
        return RedirectToAction("Login", "Account");
    }

    // TEMPORARY DEBUG: a GET endpoint you can open to test signout behavior server-side.
    // You may remove this after debugging.
    [HttpGet]
    public async Task<IActionResult> SignOutTest()
    {
        _logger.LogInformation("SignOutTest invoked. User: {User}", User.Identity?.Name ?? "<none>");
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        Response.Cookies.Delete(".AspNetCore.Cookies");
        return Content("Signed out (SignOutTest). If you still see Dashboard when visiting /Dashboard, the browser is caching pages.");
    }
}
