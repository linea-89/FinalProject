using Microsoft.AspNetCore.Mvc;
using FinalProject.RoomComponent.Services;
using FinalProject.RoomComponent.Models.Dto;

namespace FinalProject.RoomComponent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomService _roomService;

        public RoomController(ILogger<RoomController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }


        [HttpPost]
        public async Task<ActionResult> AddRoom([FromBody] RoomDto roomDto)
        {
            if (roomDto == null)
            {
                return BadRequest("Add room cannot be empty");
            }

            var result = await _roomService.AddRoom(roomDto);
            return CreatedAtAction(nameof(AddRoom), new { id = result.Id }, result);
        }

        [HttpGet("{floorId}")]
        public async Task<ActionResult<List<RoomDto>>> GetRooms(int floorId)
        {
            try
            {
                var result = await _roomService.GetRooms(floorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving rooms: {ex.Message}");
                return Problem("An error occured while retrieving rooms");
            }
        }

        [HttpGet("{floorId}/{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int floorId, int id)
        {
            try
            {
                var result = await _roomService.GetRoomById(floorId, id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving room with id {floorId}: {ex.Message}");
                return Problem("An error occured while retrieving room");
            }
        }

        [HttpPost("type")]
        public async Task<ActionResult> CreateRoomType(RoomTypeDto roomTypeDto)
        {
            if (roomTypeDto == null)
            {
                return BadRequest("Create room cannot be empty");
            }

            var result = await _roomService.CreateRoomType(roomTypeDto);
            return CreatedAtAction(nameof(CreateRoomType), new { id = result.Id }, result);
        }

        [HttpGet("type")]
        public async Task<ActionResult<List<RoomTypeDto>>> GetRoomTypes()
        {
            try
            {
                var result = await _roomService.GetRoomTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving room types: {ex.Message}");
                return Problem("An error occured while retrieving room types");
            }
        }
    }
}
