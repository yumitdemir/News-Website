using DSS.Repository.Sessions;
using DSS.Repository.TagsRepository;
using DSS.Repository;
using DSS.Service.NewsService;
using Microsoft.AspNetCore.Hosting;
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

namespace Tests
{
    public class NewsControllerTests
    {
        
        private readonly INewsRepository _newsRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IWebHostEnvironment _env;
        private readonly INewsService _newsService;
        private readonly NewsController _newsController;


        public NewsControllerTests()
        {
            //Dependency
            _newsService = A.Fake<INewsService>();
            _newsRepository = A.Fake<INewsRepository>();
            _accountRepository = A.Fake<IAccountRepository>();
            _tagRepository = A.Fake<ITagRepository>();
            _env = A.Fake<IWebHostEnvironment>();
            //SUT

            _newsController = new NewsController(_newsRepository, _accountRepository, _tagRepository, _env, _newsService);

        }

        [Fact]
        public void HomeController_AddNewsv_ReturnsSuccess()
        {
            // Arrange
       

            //Act
            var result = _newsController.AddNews();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void HomeController_AddNews_ReturnsSuccess()
        {
            // Arrange
            string title = "test";
            string content = "test";
            string tag = null;
            IFormFile thumbnailImg = null;
            var error = new List<ErrorDTO>();
            A.CallTo(() => _newsService.ValidateNewsModel(title, content, tag, thumbnailImg)).Returns(error);
            TagModel tempTag = new TagModel();
            A.CallTo(() => _tagRepository.getTagByNameAsync(tag)).Returns(tempTag);


            //Act
            var result = _newsController.AddNews(title, content, tag, thumbnailImg);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
