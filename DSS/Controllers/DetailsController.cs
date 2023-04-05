using DSS.Data;
using DSS.Models;
using DSS.Repository;
using DSS.Repository.CommentRepository;
using DSS.Repository.Detail;
using DSS.Repository.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace DSS.Controllers
{
    public class DetailsController : Controller
    {
       
        private readonly IDetailRepository _detailRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly INewsRepository _newsRepository;

        public DetailsController(INewsRepository newsRepository,IDetailRepository detailRepository, ICommentRepository commentRepository,IAccountRepository accountRepository)
        {
            _newsRepository = newsRepository;
             _detailRepository = detailRepository;
            _commentRepository = commentRepository;
            _accountRepository = accountRepository;
        }

        public async Task<IActionResult> Index(int newsId)
        {
            
           
            NewsModel news = await _detailRepository.GetByIdAsync(newsId);

            DetailDTO detailDto = new DetailDTO();
            detailDto.news = news;
            detailDto.comments = _commentRepository.getCommentsByNewsIdAsync(newsId).Result;
            detailDto.currentUser =  _accountRepository.getSesionUser(HttpContext.Session.GetString("username"))?.Result;
           


            return View(detailDto);
        }

        [HttpPost]
        public IActionResult Index(string content, int newsId)
        {
            if (HttpContext.Session.GetString("username") == null) return RedirectToAction("Index");
            
            

            CommentModel newComment = new CommentModel();
            newComment.Content = content;
            newComment.UserModel =  _accountRepository.getSesionUser(HttpContext.Session.GetString("username")).Result;
            newComment.NewsModel = _newsRepository.getNewsById(newsId).Result;
           
            _commentRepository.addComment(newComment);


            return RedirectToAction("Index");
        }
    }
}
