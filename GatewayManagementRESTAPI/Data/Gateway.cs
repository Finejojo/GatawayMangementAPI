using System.ComponentModel.DataAnnotations;

namespace GatewayManagementRESTAPI.Data
{
    public class Gateway
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4Address { get; set; }
        public List<PeripheralDevice> PeripheralDevices { get; set; }
    }
}
