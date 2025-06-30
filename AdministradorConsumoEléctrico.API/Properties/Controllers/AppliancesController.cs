using AdministradorConsumoEléctrico.API.Dtos;
using AdministradorConsumoEléctrico.Infrastructure.Data.Repositories;
using AdministradorConsumoEléctrico.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdministradorConsumoEléctrico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppliancesController : ControllerBase
    {
        private readonly GenericRepository<Appliance> _applianceRepository;

        public AppliancesController(GenericRepository<Appliance> applianceRepository)
        {
            _applianceRepository = applianceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppliances()
        {
            var appliances = await _applianceRepository.GetAllAsync();
            return Ok(appliances);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetApplianceById(int id)
        {
            if (id <= 0) return BadRequest("Invalid appliance ID.");
            var appliance = await _applianceRepository.GetByIdAsync(id);
            if (appliance == null) return NotFound("Appliance not found.");
            return Ok(appliance);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppliance([FromBody] CreateApplianceDto request)
        {
            if (request == null)
                return BadRequest("Appliance data is required.");

            if (string.IsNullOrWhiteSpace(request.Name) || request.PowerWatts <= 0)
                return BadRequest("Invalid appliance data.");

            var appliance = new Appliance
            {
                Name = request.Name,
                PowerWatts = request.PowerWatts,
                Category = request.Category,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            appliance = await _applianceRepository.CreateAsync(appliance);

            return Ok(appliance);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppliance([FromBody] UpdateApplianceDto request)
        {
            if (request == null || request.Id <= 0)
                return BadRequest("Invalid appliance ID.");

            var existing = await _applianceRepository.GetByIdAsync(request.Id);
            if (existing == null)
                return NotFound("Appliance not found.");

            existing.Name = request.Name;
            existing.PowerWatts = request.PowerWatts;
            existing.Category = request.Category;
            existing.UpdatedAt = DateTime.UtcNow;

            await _applianceRepository.UpdateAsync(existing);
            return Ok(existing);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAppliance(int id)
        {
            var existing = await _applianceRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound("Appliance not found.");

            var result = await _applianceRepository.DeleteAsync(id);
            if (!result)
                return BadRequest("Failed to delete appliance.");

            return NoContent();
        }
    }
}

