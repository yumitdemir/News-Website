using DSS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DSS.Data;
using DSS.Repository;
using System;
using DSS.Service.HomeService;


namespace DSS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDBContext _context;
    private readonly INewsRepository _newsRepository;
    private readonly IHomeService _homeService;

    public HomeController(ILogger<HomeController> logger, ApplicationDBContext context, INewsRepository newsRepository,IHomeService homeService)
    {
        _homeService = homeService;
        _context = context;
        _logger = logger;
        _newsRepository = newsRepository;
    }

    public async Task<IActionResult> Index(int id)
    {
        

        var sessionFlag = HttpContext.Session.GetString("username") == null;
        ViewBag.SessionFlag = sessionFlag;




        var takeStart = id * 10 - 10;
        if (takeStart == 0) takeStart = 0;

        
        IEnumerable<NewsModel?> newsList = await _newsRepository.getAllNewsAsync();
        var dataTransfer = new NewsDTO();
        dataTransfer.latestNewsList = newsList.Reverse().Take(4).ToList();
        dataTransfer.mainNewsList = _homeService.getMainNewsList(newsList.ToList());
        dataTransfer.allNewsList = newsList.Reverse().Skip(4).Skip(takeStart).Take(10).ToList();
        dataTransfer.newsCount = newsList.Reverse().Skip(4).Count();

        var pageCount = Math.Ceiling(dataTransfer.newsCount / 10);




        if (id <= 0)
            return RedirectToAction("Index", "Home", new { id = 1 });

        if (id > pageCount && id != 1)
            return RedirectToAction("Index", "Home", new { id = pageCount });


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