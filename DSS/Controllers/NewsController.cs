using DSS.Data;
using DSS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DSS.Repository;

namespace DSS.Controllers
{
    public class NewsController : Controller
    {
        public readonly  ApplicationDBContext _context;
        private readonly INewsRepository _newsRepository;

        public NewsController(ApplicationDBContext context,INewsRepository newsRepository)
        {
            _context = context;
            _newsRepository = newsRepository;
        }

        public IActionResult AddNews()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddNews(string title, string content,string thumbnailImgUrl, string tag)
        {
           var currentUserName =  HttpContext.Session.GetString("username");
           var currentUser = _context.Users.FirstOrDefault(x=>x.Username == currentUserName);

           var tagId = _context.Tags.FirstOrDefault(x => x.Name == tag);


            NewsModel tempNew = new NewsModel();
            tempNew.Title = title;
            tempNew.Content = content;
            tempNew.ThumbnailImgUrl = thumbnailImgUrl;
            tempNew.UserModel = currentUser;
            tempNew.TagModel = tagId;

            _newsRepository.SaveNews(tempNew);

            return RedirectToAction("Index","Home");
        }


    }
}
