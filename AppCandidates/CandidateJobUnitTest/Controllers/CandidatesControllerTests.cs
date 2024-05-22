using AppCandidates.CandidateServices;
using AppCandidates.Controllers;
using AppCandidates.Models;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CandidateJobUnitTest.Controllers
{
    public class CandidatesControllerTests
    {
        private readonly CandidatesController _controller;
        private readonly Mock<ICandidateService> _mockService;
        private readonly IFixture _fixture;

        public CandidatesControllerTests()
        {
            _mockService = new Mock<ICandidateService>();
            _controller = new CandidatesController(_mockService.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CreateOrUpdateCandidate_ShouldReturnOkResult_WhenModelStateIsValid()
        {
            // Arrange
            var candidate = _fixture.Build<Candidate>()
                                    .With(c => c.Email, "achraf@gmail.com")
                                    .Create();
            _mockService.Setup(service => service.CreateOrUpdateCandidateAsync(candidate)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateOrUpdateCandidate(candidate);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task CreateOrUpdateCandidate_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var candidate = _fixture.Build<Candidate>()
                                    .With(c => c.Email, "achraf@gmail.com")
                                    .Create();
            _controller.ModelState.AddModelError("Email", "Required");

            // Act
            var result = await _controller.CreateOrUpdateCandidate(candidate);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}