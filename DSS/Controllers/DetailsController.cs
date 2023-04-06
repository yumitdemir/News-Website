using DSS.Data;
using DSS.Models;
using DSS.Repository;
using DSS.Repository.CommentRepository;
using DSS.Repository.Detail;
using DSS.Repository.Sessions;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DSS.Controllers;

public class DetailsController : Controller
{
    private readonly IDetailRepository _detailRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly INewsRepository _newsRepository;
    

    public DetailsController(INewsRepository newsRepository, IDetailRepository detailRepository,
        ICommentRepository commentRepository, IAccountRepository accountRepository)
    {
        _newsRepository = newsRepository;
        _detailRepository = detailRepository;
        _commentRepository = commentRepository;
        _accountRepository = accountRepository;
    }

    public async Task<IActionResult> Index(int newsId)
    {
        var sessionFlag = HttpContext?.Session?.GetString("username") == null;
        ViewBag.SessionFlag = sessionFlag;

        var isNewsNull = await _newsRepository.getNewsById(newsId);
        if (isNewsNull == null)
        {
            return RedirectToAction("Index", "Home");
        }

      

        var news = await _detailRepository.GetByIdAsync(newsId);

        var detailDto = new DetailDTO();
        detailDto.news = news;
        var comments = await _commentRepository.getCommentsByNewsIdAsync(newsId);
        detailDto.comments = comments.Reverse();
        detailDto.currentUser = _accountRepository.getSesionUser(HttpContext.Session.GetString("username"))?.Result;

       


        return View(detailDto);
    }

    [HttpPost]
    public IActionResult Index(string content, int newsId)
    {
        if (HttpContext.Session.GetString("username") == null) return RedirectToAction("Index");


        var newComment = new CommentModel();
        newComment.Content = content;
        newComment.UserModel = _accountRepository.getSesionUser(HttpContext.Session.GetString("username")).Result;
        newComment.NewsModel = _newsRepository.getNewsById(newsId).Result;

        _commentRepository.addComment(newComment);


        return RedirectToAction("Index");
    }

    [HttpPost]
    [Route("details/{currentUsername}/comments/remove/{id}")]
    public IActionResult removeComment(int id, string currentUsername)
    {
        
        if (HttpContext.Session.GetString("username") != currentUsername)
            return new JsonResult(new { status = "unsuccessful" });

        _commentRepository.removeCommentById(id);

        var result = new { status = "success" };
        return new JsonResult(result);
    }

    [HttpPost]
    [Route("details/{currentUsername}/news/remove/{id}")]
    public IActionResult removeNews(int id, string currentUsername)
    {
        if (HttpContext.Session.GetString("username") != currentUsername)
            return new JsonResult(new { status = "unsuccessful" });

        _newsRepository.RemoveNewsById(id);

        var result = new { status = "success" };
        return new JsonResult(result);
    }
}