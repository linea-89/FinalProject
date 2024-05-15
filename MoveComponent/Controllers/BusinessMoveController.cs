using FinalProject.MoveComponent.Models.Dto;
using FinalProject.MoveComponent.Services.BusinessMove;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FinalProject.MoveComponent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessMoveController : ControllerBase
    {

        private readonly ILogger<BusinessMoveController> _logger;
        private readonly IBusinessMoveService _businessMoveService;

        public BusinessMoveController(ILogger<BusinessMoveController> logger, IBusinessMoveService businessMoveService)
        {
            _logger = logger;
            _businessMoveService = businessMoveService;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterBusinessMove([FromBody] BusinessMoveDto businessMoveDto)
        {
            if (businessMoveDto == null)
            {
                return BadRequest("BusinessMoveDto cannot be null.");
            }

            try
            {
                var createdBusinessMove = await _businessMoveService.CreateBusinessMoveAsync(businessMoveDto);
                return CreatedAtAction(nameof(RegisterBusinessMove), new { id = createdBusinessMove.Id }, createdBusinessMove);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error when saving move: {ex.Message}");
                return StatusCode(500, "An error occurred while saving to the database.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<BusinessMoveDto>>> GetBusinessMoves()
        {
            try
            {
                var result = await _businessMoveService.GetBusinessMoves();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving moves: {ex.Message}");
                return Problem("An error occured while retrieving moves");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessMoveDto>> GetBusinessMove(int id)
        {
            try
            {
                var result = await _businessMoveService.GetBusinessMoveByIdAsync(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in retrieving move with id {id}: {ex.Message}");
                return Problem("An error occured while retrieving move");
            }
        }


        // GET: MoveController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: MoveController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: MoveController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: MoveController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
