using Microsoft.EntityFrameworkCore;

namespace GatewayManagementRESTAPI.Data
{
    public class GatewayContext : DbContext
    {
        public GatewayContext(DbContextOptions<GatewayContext> options) : base(options)
        {

        }

        public DbSet<Gateway> Gateways { get; set; }
      public DbSet<PeripheralDevice> PeripheralDevices { get; set; }
    }
}
