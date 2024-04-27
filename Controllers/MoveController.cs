using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/move/[controller]")]
    [Produces("application/json")]
    public class MoveController : ControllerBase
    {

        private readonly ILogger<MoveController> _logger;
        //private readonly IMoveService _moveService;

        public MoveController(ILogger<MoveController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        // GET: MoveController
        public ActionResult Index(string text)
        {
            try
            {
                Console.WriteLine(text);

                if (text.Length < 0) { }
                return Ok(text);

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
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in Creating a move: {e.Message}");
                return Problem("An error occured while creating a move");
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
