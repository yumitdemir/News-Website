using DSS.Repository.CommentRepository;
using DSS.Repository.Detail;
using DSS.Repository.Sessions;
using DSS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSS.Controllers;
using FakeItEasy;
using DSS.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Tests
{
    public class DetailsControllerTests
    {
        private readonly IDetailRepository _detailRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly INewsRepository _newsRepository;

        private readonly DetailsController _detailsController;

        public DetailsControllerTests()
        {
            _newsRepository = A.Fake<INewsRepository>();
            _detailRepository = A.Fake<IDetailRepository>();
            _commentRepository = A.Fake<ICommentRepository>();
            _accountRepository = A.Fake<IAccountRepository>();

            _detailsController = new DetailsController(_newsRepository, _detailRepository, _commentRepository, _accountRepository);
        }

        [Fact]
        public void DetailsController_Index_ReturnsSuccess()
        {
            // Arrange
            int newsId = 1;
            var isNewsNull = A.Fake<NewsModel> ();
            A.CallTo(() => _newsRepository.getNewsById(newsId)).Returns(isNewsNull);

            var news = A.Fake<NewsModel>();
            A.CallTo(() => _detailRepository.GetByIdAsync(newsId)).Returns(news);

            var comments = A.Fake<IEnumerable<CommentModel>>();
            A.CallTo(() => _commentRepository.getCommentsByNewsIdAsync(newsId)).Returns(comments);

            //Act
            var result = _detailsController.Index(newsId);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void DetailsController_IndexHttpPost_ReturnsSuccess()
        {
            // Arrange
            int newsId = 1;
            string content = "dsadas";

            var mockSession = new Mock<ISession>();
            _detailsController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { Session = mockSession.Object }
            };

            var newComment = new CommentModel();
            newComment.UserModel = A.Fake<UserModel>();
            newComment.Content = "tesst";
            newComment.NewsModel = A.Fake<NewsModel>();

            _commentRepository.addComment(newComment);

            //Act
            var result = _detailsController.Index(newsId);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }


        [Fact]
        public void DetailsController_RemoveComment_ReturnsSuccess()
        {
            // Arrange
            int newsId = 1;
            var currentUsername = "username";

            var mockSession = new Mock<ISession>();
            
          
        _detailsController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { Session = mockSession.Object },
            };
        _detailsController.HttpContext.Session.Set("username", Encoding.UTF8.GetBytes("username"));

            


            _commentRepository.removeCommentById(newsId);

            //Act
            var result = _detailsController.removeComment(newsId,currentUsername);

            //Assert
            result.Should().BeOfType<JsonResult>();

        }



    }
}
