using FakeItEasy;
using FluentAssertions;
using GatewayManagementRESTAPI.Controllers;
using GatewayManagementRESTAPI.Data;
using GatewayManagementRESTAPI.Repository;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectGateway.Gateways
{
    public class GatewayControllerTest
    {
        //private readonly GatewayContext _gatewayContext;
        private readonly IGatewayRepository _gatewayRepository; 

        public GatewayControllerTest()
        {
            _gatewayRepository = A.Fake<IGatewayRepository>();
        }

        [Fact]
        public void GetgatewaysController_Getgateways_ReturnOk()
        {
            // Arrange 
            var gateways = A.Fake<ICollection<Gateway>>();
            var gateList = A.Fake<List<Gateway>>();

            var controller = new GatewayController(_gatewayRepository);


            // Act 
            var result = controller.GetGateways();

            // Assert
            result.Should().NotBeNull();
        }
    }
}
