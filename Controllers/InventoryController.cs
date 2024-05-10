using FinalProject.Models;
using FinalProject.Services.Inventory;
using FinalProject.Services.Room;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }



        [HttpPost("type")]
        public async Task<IActionResult> CreateInventoryType(InventoryTypeDto inventoryTypeDto)
        {
            if (inventoryTypeDto == null)
            {
                return BadRequest("Create inventory cannot be empty");
            }

            var result = await _inventoryService.CreateInventoryType(inventoryTypeDto);
            return CreatedAtAction(nameof(CreateInventoryType), new { id = result.Id }, result);
        }

       /* [HttpGet("type")]
        public ActionResult<List<RoomTypeDto>> GetRoomTypes()
        {
            try
            {
                var result = _roomService.GetRoomTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving room types: {ex.Message}");
                return Problem("An error occured while retrieving room types");
            }

        }*/

    }
}
