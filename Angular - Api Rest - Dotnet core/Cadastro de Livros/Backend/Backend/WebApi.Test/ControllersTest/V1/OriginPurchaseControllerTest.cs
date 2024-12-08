using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Web.Api.Controllers.V1;

namespace WebApi.Test.ControllersTest.V1
{
    public class OriginPurchaseControllerTest : IDisposable
    {
        private readonly Mock<IOriginPurchaseRepository> mockRepository;
        private readonly IOriginPurchaseRepository _repository;
        private readonly Mock<ILogger<OriginPurchaseController>> _mockLogger;
        private readonly ILogger<OriginPurchaseController> _logger;
        private readonly OriginPurchaseController _controller;

        private bool _disposed = false;

        OriginPurchase obj = new OriginPurchase
        {
            OriginPurchaseId = 1,
            Name = "Test"
        };

        IList<OriginPurchase> list = new List<OriginPurchase>
        {
            new OriginPurchase
            {
                OriginPurchaseId = 1,
                Name = "Test"
            },
            new OriginPurchase
            {
                OriginPurchaseId = 1,
                Name = "Test"
            }
        };

        public OriginPurchaseControllerTest()
        {
            mockRepository = new(MockBehavior.Strict);
            mockRepository.Setup(a => a.Get(1)).Returns(() => obj);
            mockRepository.Setup(a => a.GetAsync()).ReturnsAsync(() => list);
            mockRepository.Setup(a => a.AddAsync(obj)).ReturnsAsync(() => obj);
            mockRepository.Setup(a => a.UpdateAsync(obj)).ReturnsAsync(() => obj);
            mockRepository.Setup(a => a.RemoveAsync(1)).Returns(() => Task.Run(() => { }));

            _repository = mockRepository.Object;

            _mockLogger = new(MockBehavior.Strict);
            _logger = _mockLogger.Object;

            _controller = new OriginPurchaseController(_logger, _repository);
        }

        [Fact]
        public async void GetAllReturnTest()
        {
            var actionResult = await _controller.GetAsync();
            var result = actionResult.Result as OkObjectResult;

            Assert.Equal(result?.Value, list);
            Mock.Get(_repository).Verify(a => a.GetAsync());
        }

        [Fact]
        public void GetIdReturnTest()
        {
            var actionResult = _controller.Get(1);
            var result = actionResult.Result as OkObjectResult;

            Assert.Equal(result?.Value, obj);
            Mock.Get(_repository).Verify(a => a.Get(1));
        }

        [Fact]
        public async void PostReturnTest()
        {
            var actionResult = await _controller.PostAsync(obj);
            var result = actionResult.Result as OkObjectResult;

            Assert.Equal(result?.Value, obj);
            Mock.Get(_repository).Verify(a => a.AddAsync(obj));
        }

        [Fact]
        public async void PutReturnTest()
        {
            var actionResult = await _controller.PutAsync(1, obj);
            var result = actionResult.Result as OkObjectResult;

            Assert.Equal(result?.Value, obj);
            Mock.Get(_repository).Verify(a => a.UpdateAsync(obj));
        }

        [Fact]
        public async void PutValidateDiffIdest()
        {
            var actionResult = await _controller.PutAsync(2, obj);
            var result = actionResult.Result as BadRequestObjectResult;

            Assert.Equal(result?.Value, "Id de atualização do objecto não confere.");
            Assert.Equal(result?.StatusCode, 400);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void DeleteReturnTest()
        {
            var actionResult = await _controller.DeleteAsync(1);

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

        ~OriginPurchaseControllerTest()
        {
            mockRepository.Reset();
            Dispose(false);
        }

    }
}
