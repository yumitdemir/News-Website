using DSS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DSS.Data;


namespace DSS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDBContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDBContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index(int id)
    {

        var sessionFlag = HttpContext.Session.GetString("username") == null;
        ViewBag.SessionFlag = sessionFlag;
        var dataTransfer = new NewsDTO();

        if (id <= 0)
            return RedirectToAction("Index", "Home", new { id = 1 });

        var takeStart = (id * 10)-10;
        if (takeStart == 0)
        {
            takeStart = 0;
        }

        if ( _context.News == null)
        {
            Console.WriteLine("dsadsasda");
            return View(dataTransfer);
        }
        dataTransfer.latestNewsList = _context.News.Take(4).ToList();
        dataTransfer.mainNewsList = _context.News.Take(5).ToList();
        dataTransfer.allNewsList = _context.News.Skip(4).Skip(takeStart).Take(10).ToList();
        dataTransfer.newsCount = _context.News.Skip(4).Count();

        
         var pageCount = Math.Ceiling(dataTransfer.newsCount / 10);

         if (pageCount < id-1 && pageCount == 0)
        {
            return RedirectToAction("Index", "Home", new { id = 1 });
        }

        return View(dataTransfer);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}