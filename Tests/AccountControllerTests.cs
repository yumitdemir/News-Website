using DSS.Controllers;
using DSS.Models;
using DSS.Repository.CommentRepository;
using DSS.Repository.Detail;
using DSS.Repository.Sessions;
using DSS.Repository;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSS.Repository.UserRepository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace Tests
{
    public class AccountControllerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountService;
        private readonly AccountController _accountController;


        public AccountControllerTests()
        {
            
            _userRepository = A.Fake<IUserRepository>();
            _accountService = A.Fake<IAccountRepository>();

            _accountController = new AccountController( _accountService, _userRepository);
        }



        [Fact]
        public void DetailsController_SignIn_ReturnsSuccess()
        {
            // Arrange
          

            var mockSession = new Mock<ISession>();


            _accountController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { Session = mockSession.Object },
            };
            _accountController.HttpContext.Session.Set("username", Encoding.UTF8.GetBytes("username"));

            //Act
            var result = _accountController.SignIn();

            //Assert
            Assert.IsType<ViewResult>(result);

        }


        [Fact]
        public void DetailsController_Welcome_ReturnsSuccess()
        {
            // Arrange
            var mockSession = new Mock<ISession>();

            var mockView = new Mock<IView>();
            var mockViewDataDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            mockViewDataDictionary["Message1"] = "Your mock message here"; 
          

            _accountController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { Session = mockSession.Object },
            };
            _accountController.HttpContext.Session.Set("username", Encoding.UTF8.GetBytes("username"));

            //Act
            var result = _accountController.Welcome();

            //Assert
            Assert.IsAssignableFrom<ActionResult>(result);

        }


        [Fact]
        public void DetailsController_SignUp_ReturnsSuccess()
        {
            // Arrange


            var mockSession = new Mock<ISession>();


            _accountController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { Session = mockSession.Object },
            };
            _accountController.HttpContext.Session.Set("username", Encoding.UTF8.GetBytes("username"));

            //Act
            var result = _accountController.SignUp();

            //Assert
            Assert.IsType<ViewResult>(result);

        }


        [Fact]
        public void DetailsController_SignUpHTTP_ReturnsSuccess()
        {
            string username = "testuser";
            string password = "testpassword";

            var mockAccountService = new Mock<IAccountRepository>();
            mockAccountService.Setup(s => s.Register(username)).Returns(true);

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(r => r.addUser(It.IsAny<UserModel>())).Verifiable();

            

            // Act
            var result = _accountController.SignUp(username, password);

            // Assert

            Assert.IsType<ViewResult>(result);

        }

     


    }
}
