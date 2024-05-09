using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using AutoMapper;
using FinalProject.Services.Move;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateMoveController : ControllerBase
    {
        private readonly ILogger<PrivateMoveController> _logger;
        private readonly IPrivateMoveService _privateMoveService;
        //private readonly FinalProjectContext _context;
        //private readonly IMapper _mapper;

        public PrivateMoveController(ILogger<PrivateMoveController> logger, IPrivateMoveService privateMoveService, FinalProjectContext context, IMapper mapper)
        {
            _logger = logger;
            _privateMoveService = privateMoveService;
            //_context = context;
            //_mapper = mapper;
        }

        // GET: api/PrivateMoves
        [HttpGet]
        public ActionResult<List<PrivateMoveDto>> GetPrivateMoves()
        {
            try
            {
                // Retrieve the data using the service
                var privateMoveDtos = _privateMoveService.GetPrivateMoves();

                // Return the result wrapped in an Ok() response
                return Ok(privateMoveDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving private moves: {ex.Message}");
                return Problem("An error occured while retrieving private moves");
            }

        }

        //Done
        // GET: api/PrivateMoves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateMoveDto>> GetPrivateMove(int id)
        {
            var privateMoveDto = await _privateMoveService.GetPrivateMoveByIdAsync(id);

            if (privateMoveDto == null)
            {
                return NotFound();
            }

            return privateMoveDto;
        }

        // PUT: api/PrivateMoves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPrivateMove(int id, Move privateMove)
        //{
        //    if (id != privateMove.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(privateMove).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PrivateMoveExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //Done
        [HttpPost]
        public async Task<IActionResult> RegisterPrivateMoveNew([FromBody] PrivateMoveDto privateMoveDto)
        {
            if (privateMoveDto == null)
            {
                return BadRequest("PrivateMoveDto cannot be null.");
            }

            try
            {
                var createdPrivateMove = await _privateMoveService.CreatePrivateMoveAsync(privateMoveDto);
                return CreatedAtAction(nameof(RegisterPrivateMoveNew), new { id = createdPrivateMove.Id }, createdPrivateMove);
            }
            catch (DbUpdateException ex)
            {
                // Handle the exception based on your specific requirements
                return StatusCode(500, "An error occurred while saving to the database.");
            }
        }


        // DELETE: api/PrivateMoves/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeletePrivateMove(int id)
    //    {
    //        var privateMove = await _context.Moves.FindAsync(id);
    //        if (privateMove == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Moves.Remove(privateMove);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    private bool PrivateMoveExists(int id)
    //    {
    //        return _context.Moves.Any(e => e.Id == id);
    //    }
    }
}
