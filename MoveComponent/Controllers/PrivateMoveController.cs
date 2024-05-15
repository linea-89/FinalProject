using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.MoveComponent.Services.PrivateMove;
using FinalProject.MoveComponent.Models.Dto;



namespace FinalProject.MoveComponent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateMoveController : ControllerBase
    {
        private readonly ILogger<PrivateMoveController> _logger;
        private readonly IPrivateMoveService _privateMoveService;

        public PrivateMoveController(ILogger<PrivateMoveController> logger, IPrivateMoveService privateMoveService)
        {
            _logger = logger;
            _privateMoveService = privateMoveService;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterPrivateMove([FromBody] PrivateMoveDto privateMoveDto)
        {
            if (privateMoveDto == null)
            {
                return BadRequest("PrivateMoveDto cannot be null.");
            }

            try
            {
                var createdPrivateMove = await _privateMoveService.CreatePrivateMoveAsync(privateMoveDto);
                return CreatedAtAction(nameof(RegisterPrivateMove), new { id = createdPrivateMove.Id }, createdPrivateMove);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error in retrieving private moves: {ex.Message}");
                return StatusCode(500, "An error occurred while saving to the database.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PrivateMoveDto>>> GetPrivateMoves()
        {
            try
            {
                var result = await _privateMoveService.GetPrivateMovesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving moves: {ex.Message}");
                return Problem("An error occured while retrieving moves");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateMoveDto>> GetPrivateMove(int id)
        {
            try
            {
                var result = await _privateMoveService.GetPrivateMoveByIdAsync(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving move with id {id}: {ex.Message}");
                return Problem("An error occured while retrieving move");
            }
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


        //    // DELETE: api/PrivateMoves/5
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
