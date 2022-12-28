using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using Application.Queries.TeamQueries;

namespace UnitTestProject2
{
    [TestClass]
    public class TeamsControllerFisture
    {


        public Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [TestMethod]
        public async Task GetUserTeams_ShoulReturnTeams()
        {
            //Arrange
            object value = _mockMediator.Setup(m=>m.Send(It.IsAny<GetTaskQuery>() ));

        }
        
        
    }
}
