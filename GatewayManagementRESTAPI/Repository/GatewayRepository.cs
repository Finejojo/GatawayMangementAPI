using GatewayManagementRESTAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;



namespace GatewayManagementRESTAPI.Repository
{
    public class GatewayRepository : IGatewayRepository
    {
        private readonly GatewayContext _context;
        public GatewayRepository(GatewayContext context)
        {
            _context = context;
        }

        public async Task<Gateway> CreateGatewayAsync(Gateway gateway)
        {
            await _context.Gateways.AddAsync(gateway);
            await _context.SaveChangesAsync();
            return gateway;
        }

        public async Task<IEnumerable<Gateway>> GetAllGatewaysAsync()
        {
            var gateways = await _context.Gateways.ToListAsync();
            return gateways;
        }

        public async Task<Gateway> GetSingleGatewayByIdAsync(int id)
        {
            var gateway = await _context.Gateways
                .Include(x => x.Id == id)
                .FirstOrDefaultAsync();


                return gateway;

        }

        public async Task UpdateGatewayAsync(int id, Gateway gateway)
        {
           var getGateway = await _context.Gateways
                .Include (x => x.Id == id)
                .FirstOrDefaultAsync();

            if (getGateway != null)
            {
                _context.Entry(gateway).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

        }
    }
}
