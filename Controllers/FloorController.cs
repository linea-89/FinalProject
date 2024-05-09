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
                return BadRequest("Add Floor cannor be empty");
            }

            var result = await _floorService.AddFloor(floorDto);
            return CreatedAtAction(nameof(AddFloor), new { id = result.Id }, result);
        }


        //[Http("type")]




    }
}
