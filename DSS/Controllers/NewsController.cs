using DSS.Data;
using DSS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DSS.Repository;
using DSS.Repository.Sessions;
using DSS.Repository.TagsRepository;
using DSS.Service.NewsService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace DSS.Controllers
{
    public class NewsController : Controller
    {
        
        private readonly INewsRepository _newsRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IWebHostEnvironment _env;
        private readonly INewsService _newsService;

        public NewsController(INewsRepository newsRepository, IAccountRepository accountRepository, ITagRepository tagRepository, IWebHostEnvironment env, INewsService newsService)
        {
            _newsService = newsService;
             _newsRepository = newsRepository;
            _accountRepository = accountRepository;
            _tagRepository = tagRepository;
            _env = env;
        }

        public IActionResult AddNews()
        {
            NewsModel tempNews = new NewsModel();
           


            return View(tempNews);
        }


        [HttpPost]
        public  async Task<IActionResult> AddNews(string title, string content, string tag, IFormFile thumbnailImg)
        {
            var errors = _newsService.ValidateNewsModel(title, content, tag, thumbnailImg);
            
            if (errors.Count() != 0)
            {
                var wrongNew = new NewsModel();
                wrongNew.Title = title;
                wrongNew.Content = content;
                var tempTag = await _tagRepository.getTagByNameAsync(tag);
                wrongNew.TagModel = tempTag;
                
                foreach (var err in errors)
                {
                    ModelState.AddModelError($"{err.key}", $"{err.errorMessage}");
                }
                return View(wrongNew);
            }



            var currentUserName = HttpContext.Session.GetString("username");
            if (currentUserName == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var currentUser = await _accountRepository.getSesionUser(currentUserName);  
            
           var selectedTag = await _tagRepository.getTagByNameAsync(tag);


            NewsModel tempNew = new NewsModel
            {
                Title = title,
                Content = content,
                UserModel = currentUser,
                TagModel = selectedTag
            };


            if (thumbnailImg != null && thumbnailImg.Length > 0)
            {
                if (thumbnailImg.ContentType != "image/png" && thumbnailImg.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ThumbnailImg", "You can only upload a PNG or JPEG file.");
                    return View("AddNews");
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(thumbnailImg.FileName);
                var uploadPath = Path.Combine(_env.WebRootPath, "Content");
                var filePath = Path.Combine(uploadPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    thumbnailImg.CopyTo(fileStream);
                }
                tempNew.ThumbnailImgUrl = $"/Content/{fileName}";
            }
            else
            {
                tempNew.ThumbnailImgUrl = null;
            }


            _newsRepository.SaveNews(tempNew);

            TempData["addNewsMessage"] = "News article added successfully";
            return RedirectToAction("Index","Home");
        }


    }
}
