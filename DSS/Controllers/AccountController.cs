using DSS.Models;
using DSS.Repository.Sessions;
using DSS.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace DSS.Controllers;

public class AccountController : Controller
{
    private IAccountRepository _accountService;
    private readonly IUserRepository _userRepository;
    private readonly bool _sessionFlag = false;

    public AccountController(IAccountRepository accountService, IUserRepository userRepository)
    {
        _accountService = accountService;
        _userRepository = userRepository;
        _sessionFlag = HttpContext?.Session?.GetString("username") == null;
    }

    public IActionResult SignIn()
    {
        if (HttpContext.Session.GetString("username") != null) return RedirectToAction("Index", "Home");
        ViewBag.SessionFlag = _sessionFlag;
        
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(string username, string password)
    {

        var account = _accountService.Login(username, password);
        if (account != null)
        {
            HttpContext.Session.SetString("username", username);
           
            TempData["loginMessage"] = "Logged in successfully";
            return RedirectToAction("Index", "Home");
        }
        else
        {
            TempData["loginFailedMessage"] = "Incorrect username or password";
            return RedirectToAction("SignIn");
        }

    }

    public IActionResult Welcome()
    {
        if (HttpContext.Session.GetString("username") == null) return RedirectToAction("Signin", "Account");


        ViewBag.Message1 = HttpContext.Session.GetString("username");
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
      
        TempData["logoutMessage"] = "Logged out successfully";
        return RedirectToAction("Index", "Home");
    }


    public IActionResult SignUp()
    {
        if (HttpContext.Session.GetString("username") != null) return RedirectToAction("Signin", "Account");
        ViewBag.SessionFlag = _sessionFlag;
       
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(string username, string password)
    {
        
        
        var isUsernameUnique = _accountService.Register(username);
        if (isUsernameUnique)
        {
            UserModel temUser = new UserModel();
            temUser.Username = username;
            temUser.Password = password;
            _userRepository.addUser(temUser);
            TempData["userRegistered"] = "Account registered successfully, please sign in";
            return RedirectToAction("SignIn");
        }
        else
        {
            ViewBag.UsernameErr = "Username already in use please choose a different username";
            
        }

        return View();
    }
}