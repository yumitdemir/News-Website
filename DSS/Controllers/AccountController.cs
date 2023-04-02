using DSS.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace DSS.Controllers;

public class AccountController : Controller
{
    private IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(string username, string password)
    {
        if (HttpContext.Session.GetString("username") != null)
        {
            return RedirectToAction("Index", "Home");
        }
        var account = _accountService.Login(username, password);
        if (account != null)
        {
            HttpContext.Session.SetString("username", username);
            return RedirectToAction("Welcome", "Account"); //! important
        }
        else
        {
            ViewBag.Message = "Invalid Login";
            return View();
        }
    }

    public IActionResult Welcome()
    {
        if (HttpContext.Session.GetString("username") == null)
        {
            return RedirectToAction("Signin", "Account");
        }

        ViewBag.Message1 = "Success login";
        ViewBag.Message2 = HttpContext.Session.GetString("username");
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("Signin", "Account");
    }


    public IActionResult SignUp()
    {
        return View();
    }
}