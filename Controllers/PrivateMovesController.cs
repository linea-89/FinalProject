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

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateMovesController : ControllerBase
    {
        private readonly FinalProjectContext _context;
        private readonly IMapper _mapper;

        public PrivateMovesController(FinalProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PrivateMoves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrivateMove>>> GetPrivateMoves()
        {
            return await _context.PrivateMoves.ToListAsync();
        }

        // GET: api/PrivateMoves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateMove>> GetPrivateMove(int id)
        {
            var privateMove = await _context.PrivateMoves.FindAsync(id);

            if (privateMove == null)
            {
                return NotFound();
            }

            return privateMove;
        }

        // PUT: api/PrivateMoves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrivateMove(int id, PrivateMove privateMove)
        {
            if (id != privateMove.Id)
            {
                return BadRequest();
            }

            _context.Entry(privateMove).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateMoveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PrivateMoves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PrivateMove>> PostPrivateMove(PrivateMoveDto newPrivateMove)
        //{
        //    var privateMove = _mapper.Map<PrivateMove>(newPrivateMove);
        //    _context.PrivateMoves.Add(privateMove);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetPrivateMove", new { id = privateMove.Id }, privateMove);
        //    return Ok(await _context.PrivateMoves.ToListAsync());
        //}

        [HttpPost]
        public async Task<IActionResult> PostPrivateMoveNew([FromBody] PrivateMoveDto privateMoveDto)
        {
            if (privateMoveDto == null)
            {
                return BadRequest("PrivateMoveDto cannot be null.");
            }

            // Map the DTO to the entity
            var privateMove = _mapper.Map<PrivateMove>(privateMoveDto);

            // Add the mapped entity to the context and save
            _context.PrivateMoves.Add(privateMove);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostPrivateMoveNew), new { id = privateMove.Name }, privateMove);
        }

        //[HttpPost]
        //public async Task<ActionResult<List<Test>>> AddTest(Test test)
        //{
        //    _context.Tests.Add(test);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Tests.ToListAsync());
        //}

        // DELETE: api/PrivateMoves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrivateMove(int id)
        {
            var privateMove = await _context.PrivateMoves.FindAsync(id);
            if (privateMove == null)
            {
                return NotFound();
            }

            _context.PrivateMoves.Remove(privateMove);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrivateMoveExists(int id)
        {
            return _context.PrivateMoves.Any(e => e.Id == id);
        }
    }
}
