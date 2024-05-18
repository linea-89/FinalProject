using Microsoft.AspNetCore.Mvc;
using FinalProject.FloorComponent.Services;
using FinalProject.FloorComponent.Dto;

namespace FinalProject.FloorComponent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly ILogger<FloorController> _logger;
        private readonly IFloorService _floorService;

        public FloorController(ILogger<FloorController> logger, IFloorService floorService)
        {
            _logger = logger;
            _floorService = floorService;
        }


        [HttpPost]
        public async Task<ActionResult> AddFloor([FromBody] FloorDto floorDto)
        {
            if (floorDto == null)
            {
                return BadRequest("Add Floor cannot be empty");
            }

            var result = await _floorService.AddFloor(floorDto);
            return CreatedAtAction(nameof(AddFloor), new { id = result.Id }, result);
        }

        [HttpGet("{moveId}")]
        public async Task<ActionResult<List<FloorDto>>> GetFloors(int moveId)
        {
            try
            {
                var result = await _floorService.GetFloors(moveId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving floors: {ex.Message}");
                return Problem("An error occured while retrieving floors");
            }
        }

        [HttpGet("{moveId}/{id}")]
        public async Task<ActionResult<FloorDto>> GetFloor(int moveId, int id)
        {
            try
            {
                var result = await _floorService.GetFloorById(moveId, id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving floor with id {id}: {ex.Message}");
                return Problem("An error occured while retrieving floor");
            }
        }

        [HttpPost("type")]
        public async Task<ActionResult> createFloorType(FloorTypeDto floorTypeDto)
        {
            if (floorTypeDto == null)
            {
                return BadRequest("Create floor cannot be empty");
            }

            var result = await _floorService.CreateFloorType(floorTypeDto);
            return CreatedAtAction(nameof(createFloorType), new { id = result.Id }, result);
        }

        [HttpGet("type")]
        public async Task<ActionResult<List<FloorTypeDto>>> GetFloorTypes()
        {
            try
            {
                var result = await _floorService.GetFloorTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving floortypes: {ex.Message}");
                return Problem("An error occured while retrieving floortypes");
            }
        }

    }
}
