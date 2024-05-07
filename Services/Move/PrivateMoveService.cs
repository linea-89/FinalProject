using AutoMapper;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.Move
{
    public class PrivateMoveService : IPrivateMoveService
    {
        private readonly FinalProjectContext _context;
        private readonly IMapper _mapper;

        public PrivateMoveService(FinalProjectContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public ActionResult<List<PrivateMoveDto>> GetAllPrivateMoves()
        {
            // Load the related entities explicitly using .Include and map to the DTO
            var privateMoves = _context.PrivateMoves
                .Include(pm => pm.Addresses) // Include related Addresses collection
                .Include(pm => pm.Amenities) // Include the Amenities navigation property
                .ToList(); // Ensure query execution to fetch the data

            // Map the result to the PrivateMoveDto list
            var privateMoveDtos = privateMoves
                .Select(privateMove => _mapper.Map<PrivateMoveDto>(privateMove))
                .ToList(); // Materialize the query into a list

            return privateMoveDtos;
        }


        //public Task<IActionResult> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto)
        //{
        //    var privateMove = _mapper.Map<PrivateMove>(privateMoveDto);

        //    // Add the mapped entity to the context and save
        //    _context.PrivateMoves.Add(privateMove);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(PostPrivateMoveNew), new { id = privateMoveDto.Name }, privateMoveDto);
        //}

        public async Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto)
        {
            var privateMove = _mapper.Map<PrivateMove>(privateMoveDto);

            // Add the mapped entity to the context and save
            _context.PrivateMoves.Add(privateMove);
            await _context.SaveChangesAsync();

            // Optionally, map the saved entity back to a DTO for return
            return _mapper.Map<PrivateMoveDto>(privateMove);
        }


    }
}
