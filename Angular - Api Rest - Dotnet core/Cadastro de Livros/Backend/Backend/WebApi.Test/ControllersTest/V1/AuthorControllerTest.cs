using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Web.Api.Controllers.V1;

namespace WebApi.Test.ControllersTest.V1
{
    public class AuthorControllerTest : IDisposable
    {
        private readonly Mock<IAuthorRepository> mockRepository;
        private readonly Mock<ILogger<AuthorController>> _mockLogger;
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorRepository _repository;
        private bool _disposed = false;

        AuthorController _controller;

        Author author = new Author
        {
            AuthorId = 1,
            Name = "Test"
        };

        IList<Author> authorList = new List<Author>
            {
                new Author
                {
                    AuthorId = 1,
                    Name = "Test"
                },
                new Author
                {
                    AuthorId = 2,
                    Name = "Test 2"
                }
            };

        public AuthorControllerTest()
        {
            mockRepository = new(MockBehavior.Strict);
            mockRepository.Setup(a => a.Get(1)).Returns(() => author);
            mockRepository.Setup(a => a.Get()).Returns(() => authorList);
            mockRepository.Setup(a => a.AddAsync(author)).ReturnsAsync(() => author);
            mockRepository.Setup(a => a.UpdateAsync(author)).ReturnsAsync(() => author);
            mockRepository.Setup(a => a.RemoveAsync(1)).Returns(() => Task.Run(() => { }));

            _repository = mockRepository.Object;

            _mockLogger = new(MockBehavior.Strict);
            _logger = _mockLogger.Object;

            _controller = new AuthorController(_logger, _repository);
        }

        [Fact]
        public async void GetAllReturnTest()
        {
            var authorActionResult = await _controller.GetAsync();
            var result = authorActionResult.Result as OkObjectResult;

            Assert.Equal(result?.Value, authorList);
            Mock.Get(_repository).Verify(a => a.Get());
        }

        [Fact]
        public void GetIdReturnTest()
        {
            var authorResult = _controller.Get(1).Result as OkObjectResult;

            Assert.Equal(authorResult?.Value, author);
            Mock.Get(_repository).Verify(a => a.Get(1));
        }

        [Fact]
        public async void PostReturnTest()
        {
            var authorActionResult = await _controller.PostAsync(author);
            var result = authorActionResult.Result as OkObjectResult;

            Assert.Equal(result?.Value, author);
            Mock.Get(_repository).Verify(a => a.AddAsync(author));
        }

        [Fact]
        public async void PutReturnTest()
        {
            var authorActionResult = await _controller.PutAsync(1, author);
            var result = authorActionResult.Result as OkObjectResult;

            Assert.Equal(result?.Value, author);
            Mock.Get(_repository).Verify(a => a.UpdateAsync(author));
        }

        [Fact]
        public async void PutValidateDiffIdest()
        {
            var authorActionResult = await _controller.PutAsync(2, author);
            var result = authorActionResult.Result as BadRequestObjectResult;

            Assert.Equal(result?.Value, "Id de atualização do objecto não confere.");
            Assert.Equal(result?.StatusCode, 400);
            Assert.IsType<BadRequestObjectResult>(authorActionResult.Result);
        }

        [Fact]
        public async void DeleteReturnTest()
        {
            var authorActionResult = await _controller.DeleteAsync(1);

            Mock.Get(_repository).Verify(a => a.RemoveAsync(1));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {

            }

            mockRepository.Reset();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~AuthorControllerTest()
        {
            mockRepository.Reset();
            Dispose(false);
        }
    }
}