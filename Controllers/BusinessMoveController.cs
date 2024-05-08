using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Services.BusinessMove;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   // [Produces("application/json")]
    public class BusinessMoveController : ControllerBase
    {

        private readonly ILogger<BusinessMoveController> _logger;
        private readonly IBusinessMoveService _businessMoveService;

        public BusinessMoveController(ILogger<BusinessMoveController> logger, IBusinessMoveService businessMoveService)
        {
            _logger = logger;
            _businessMoveService = businessMoveService;
        }

        [HttpGet]
        // GET: MoveController
        public ActionResult Index(string text)
        {
            try
            {

                var result = _businessMoveService.GetBusinessMoves();
               // if (text.Length < 0) { }
                return Ok(result);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in testing Swagger: {e.Message}");
                return Problem("An error occured while testing Swagger");
            }
        }

        // GET: MoveController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: MoveController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: MoveController/Create
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterBusinessMove([FromBody] BusinessMoveDto businessMoveDto)
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
                // Handle the exception based on your specific requirements
                return StatusCode(500, "An error occurred while saving to the database.");
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
