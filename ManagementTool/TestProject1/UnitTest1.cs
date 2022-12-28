using Application.Queries.ChatQueries;
using Application.Queries.TeamQueries;
using AutoMapper;
using ManagementTool.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using System.Net;

namespace OnlineBookStore.Tests
{
    [TestClass]
    public class TeamsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetUserTeams_ShouldReturnOk()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserTeamsQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new TeamsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetUserTeams(1) as ObjectResult;
            _mockMediator.Verify(x => x.Send(It.IsAny<GetUserTeamsQuery>(), It.IsAny<CancellationToken>()), Times.Once());

            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public async Task GetTeamChat_ShouldReturnChat()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetChatQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new TeamsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetTeamChat(7) as ObjectResult;
            _mockMediator.Verify(x => x.Send(It.IsAny<GetChatQuery>(), It.IsAny<CancellationToken>()));

            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public async Task GetById_ShouldReturnTeam()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetTeamQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new TeamsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(9) as ObjectResult;

            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}
