using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly FinalProjectContext _context;
        public TestController(FinalProjectContext context) 
        { 
            _context = context;

        }

        // GET: api/<TestController>
        [HttpGet]
        public async Task<ActionResult<List<TestDto>>> GetAllTests()
        {
            var tests = await _context.Tests.ToListAsync();

            return Ok(tests);
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public async Task<ActionResult<List<Test>>> AddTest(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tests.ToListAsync());
        }




        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
