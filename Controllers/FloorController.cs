//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using AutoMapper;
using FinalProject.Services.Move;
using FinalProject.Services.Floor;

namespace FinalProject.Controllers
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

        // [HttpGet]
        //  public ActionResult<List<FloorDto>> 


        [HttpPost]
        public async Task<IActionResult> AddFloor([FromBody] FloorDto floorDto)
        {
            if (floorDto == null)
            {
                return BadRequest("Add Floor cannot be empty");
            }

            var result = await _floorService.AddFloor(floorDto);
            return CreatedAtAction(nameof(AddFloor), new { id = result.Id }, result);
        }

        [HttpGet]
        public ActionResult<List<FloorDto>> GetFloors()
        {
            try
            {
                var result = _floorService.GetFloors();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving floors: {ex.Message}");
                return Problem("An error occured while retrieving floors");
            }

        }

        //GET: api/PrivateMoves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FloorDto>> GetFloor(int id)
        {
            try
            {
                var result = await _floorService.GetFloorByIdAsync(id);

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
        public async Task<IActionResult> createFloorType(FloorTypeDto floorTypeDto)
        {
            if (floorTypeDto == null)
            {
                return BadRequest("Create floor cannot be empty");
            }

            var result = await _floorService.createFloorType(floorTypeDto);
            return CreatedAtAction(nameof(createFloorType), new { id = result.Id }, result);
        }





    }
}
