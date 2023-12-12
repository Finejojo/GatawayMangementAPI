using GatewayManagementRESTAPI.Data;
using GatewayManagementRESTAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GatewayManagementRESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly GatewayContext _context;
        private readonly IGatewayRepository _gatewayRepository;

        public GatewayController(IGatewayRepository gatewayRepository)
        {
            _gatewayRepository = gatewayRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Gateway>> GetGateways()
        {
            var gateways = await _gatewayRepository.GetAllGatewaysAsync();
            return Ok(gateways);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gateway>> GetGateway(int id)
        {

            var gateway = await _gatewayRepository.GetSingleGatewayByIdAsync(id);
            //var gateway = await _context.Gateways.FindAsync(id);
            if (gateway == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(gateway); // 200 OK
        }

        [HttpPost]
        public async Task<ActionResult<Gateway>> PostGateway(Gateway gateway)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _gatewayRepository.CreateGatewayAsync(gateway);

            return CreatedAtAction(nameof(GetGateway), new { id = gateway.Id }, gateway);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGateway(int id, Gateway gateway)
        {
            if (id != gateway.Id)
            {
                return BadRequest("ID in the URL does not match the ID in the request body.");
            }

            await _gatewayRepository.UpdateGatewayAsync(id, gateway);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GatewayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool GatewayExists(int id)
        {
            return _context.Gateways.Any(x => x.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGateway(int id)
        {
            var gateway = await _context.Gateways.FindAsync(id);
            if (gateway == null)
            {
                return NotFound();
            }

            _context.Gateways.Remove(gateway);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
