using GatewayManagementRESTAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GatewayManagementRESTAPI.Controllers
{
    [Route("api/Gateways/{gatewayId}/[controller]")]
    [ApiController]
    public class PeripheralDevicesController : ControllerBase
    {
        private readonly GatewayContext _context;

        public PeripheralDevicesController(GatewayContext context)
        {
            _context = context;
        }

        // GET: api/Gateways/1/PeripheralDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeripheralDevice>>> GetPeripheralDevices(int gatewayId)
        {
            var gateway = await _context.Gateways.Include(g => g.PeripheralDevices)
                .FirstOrDefaultAsync(g => g.Id == gatewayId);

            if (gateway == null)
            {
                return NotFound();
            }

            return gateway.PeripheralDevices.ToList();
        }

        // POST: api/Gateways/1/PeripheralDevices
        [HttpPost]
        public async Task<ActionResult<PeripheralDevice>> PostPeripheralDevice(int gatewayId, PeripheralDevice device)
        {
            var gateway = await _context.Gateways.FindAsync(gatewayId);

            if (gateway == null)
            {
                return NotFound();
            }

            device.GatewayId = gatewayId;
            _context.PeripheralDevices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPeripheralDevices), new { gatewayId, deviceId = device.Id }, device);
        }

        // DELETE: api/Gateways/1/PeripheralDevices/5
        [HttpDelete("{deviceId}")]
        public async Task<ActionResult<PeripheralDevice>> DeletePeripheralDevice(int gatewayId, int deviceId)
        {
            var device = await _context.PeripheralDevices.FindAsync(deviceId);
            if (device == null || device.GatewayId != gatewayId)
            {
                return NotFound();
            }

            _context.PeripheralDevices.Remove(device);
            await _context.SaveChangesAsync();

            return device;
        }
    }
}
