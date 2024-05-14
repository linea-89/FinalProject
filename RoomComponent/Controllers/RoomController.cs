//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using AutoMapper;
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
        public async Task<IActionResult> AddRoom([FromBody] RoomDto roomDto)
        {
            if (roomDto == null)
            {
                return BadRequest("Add room cannot be empty");
            }

            var result = await _roomService.AddRoom(roomDto);
            return CreatedAtAction(nameof(AddRoom), new { id = result.Id }, result);
        }

        [HttpGet("{floorId}")]
        public ActionResult<List<RoomDto>> GetRooms(int floorId)
        {
            try
            {
                var result = _roomService.GetRooms(floorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving rooms: {ex.Message}");
                return Problem("An error occured while retrieving rooms");
            }

        }

        //GET: api/room/5
        [HttpGet("{floorId}/{id}")]
        public ActionResult<RoomDto> GetRoom(int floorId, int id)
        {
            try
            {
                var result = _roomService.GetRoomById(floorId, id);

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
        public async Task<IActionResult> CreateRoomType(RoomTypeDto roomTypeDto)
        {
            if (roomTypeDto == null)
            {
                return BadRequest("Create room cannot be empty");
            }

            var result = await _roomService.CreateRoomType(roomTypeDto);
            return CreatedAtAction(nameof(CreateRoomType), new { id = result.Id }, result);
        }

        [HttpGet("type")]
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

        }





    }
}
