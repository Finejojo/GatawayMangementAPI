namespace GatewayManagementRESTAPI.Data
{
    public class PeripheralDevice
    {
        public int Id { get; set; }
        public int UID { get; set; }
        public string Vendor { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public int GatewayId { get; set; }
        public Gateway Gateway { get; set; }
    }
}
