using DSS.Controllers;
using DSS.Models;
using DSS.Repository;
using DSS.Repository.CommentRepository;
using DSS.Service.HomeService;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class HomeControllerTests
    {
        
        private readonly INewsRepository _newsRepository;
        private readonly IHomeService _homeService;
        private readonly ICommentRepository _commentRepository;
        private readonly HomeController _homeController;


        public HomeControllerTests()
        {
            // Dependencies
            _commentRepository = A.Fake<ICommentRepository>();
            _homeService = A.Fake<IHomeService>();
            _newsRepository = A.Fake<INewsRepository>();

            //SUT
            _homeController = new HomeController(_newsRepository, _homeService, _commentRepository);
        }


        [Fact]
        public void HomeController_Index_ReturnsSuccess()
        {
            // Arrange
            int id = 1;
            var newsList = A.Fake<IEnumerable<NewsModel?>>();
            A.CallTo(() =>  _newsRepository.getAllNewsAsync()).Returns(newsList);
            var Commnets = A.Fake<IEnumerable<CommentModel>?>();
            A.CallTo(() => _commentRepository.getCommentsByNewsIdAsync(id)).Returns(Commnets);

            //Act
            var result = _homeController.Index(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }



    }
}