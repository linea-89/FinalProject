﻿using FinalProject.Models;
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

        [HttpPost]
        public async Task<IActionResult> AddInventoryItem([FromBody] InventoryDto inventoryDto)
        {
            if (inventoryDto == null)
            {
                return BadRequest("Add inventory cannot be empty");
            }

            var result = await _inventoryService.AddInventoryItem(inventoryDto);
            return CreatedAtAction(nameof(AddInventoryItem), new { id = result.Id }, result);
        }

        [HttpGet("{roomId}")]
        public ActionResult<List<InventoryDto>> GetInventoryItem(int roomId)
        {
            try
            {
                var result = _inventoryService.GetInventoryItem(roomId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving rooms: {ex.Message}");
                return Problem("An error occured while retrieving rooms");
            }

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

       [HttpGet("type")]
        public ActionResult<List<InventoryTypeDto>> GetInventoryTypes()
        {
            try
            {
                var result = _inventoryService.GetInventoryTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving inventory types: {ex.Message}");
                return Problem("An error occured while retrieving inventory types");
            }

        }

    }
}
