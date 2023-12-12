using GatewayManagementRESTAPI.Data;

namespace GatewayManagementRESTAPI.Repository
{
    public interface IGatewayRepository
    {
        Task<IEnumerable<Gateway>> GetAllGatewaysAsync();
        Task<Gateway> GetSingleGatewayByIdAsync(int id);
        Task<Gateway> CreateGatewayAsync(Gateway gateway);
        Task UpdateGatewayAsync(int id, Gateway gateway);
    }
}
