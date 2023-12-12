//using GatewayManagementRESTAPI.Data;
//using Microsoft.EntityFrameworkCore;
//using Xunit;

//namespace GatewayManagementRESTAPI.Test
//{
  
//        public class GatewayTests
//        {
//            [Fact]
//            public async Task Add_PeripheralDevice_To_Gateway_Should_Work()
//            {
//                // Arrange
//                var options = new DbContextOptionsBuilder<GatewayContext>()
//                    .UseInMemoryDatabase(databaseName: "TestDatabase")
//                    .Options;

//                // Mock DbContext
//                using (var context = new GatewayContext(options))
//                {
//                    var gateway = new Gateway
//                    {
//                        // Setup Gateway properties
//                        // e.g., Id, SerialNumber, IPAddress, etc.
//                    };

//                    context.Gateways.Add(gateway);
//                    await context.SaveChangesAsync();

//                    var peripheralDevice = new PeripheralDevice
//                    {
//                        // Setup PeripheralDevice properties
//                        // e.g., Id, Name, Vendor, GatewayId, etc.
//                    };

//                    // Act
//                    gateway.PeripheralDevices.Add(peripheralDevice);
//                    await context.SaveChangesAsync();

//                    // Assert
//                    var addedPeripheralDevice = await context.PeripheralDevices.FirstOrDefaultAsync(p => p.Id == peripheralDevice.Id);
//                    Assert.NotNull(addedPeripheralDevice);
//                    Assert.Equal(peripheralDevice.Name, addedPeripheralDevice.Name);
//                    // Add more assertions as needed to test the behavior
//                }
//            }

//            // Add more test methods for other functionalities of the Gateway model
//        }
//    }

//}
//}
