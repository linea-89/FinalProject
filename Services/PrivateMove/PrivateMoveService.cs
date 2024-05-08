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

        public ActionResult<List<PrivateMoveDto>> GetPrivateMoves()
        {
            var privateMoves = _context.Moves
                .Include(x => x.Addresses) // Include related Addresses collection
                .Include(x => x.Amenities)
                .Where(x => x.Type == "private")// Include the Amenities navigation property
                .ToList(); // Ensure query execution to fetch the data

            // Map the result to the PrivateMoveDto list
            var privateMoveDtos = privateMoves
                .Select(privateMove => _mapper.Map<PrivateMoveDto>(privateMove))
                .ToList(); // Materialize the query into a list

            return privateMoveDtos;
        }

        public async Task<PrivateMoveDto> GetPrivateMoveByIdAsync(int id)
        {
            var privateMove = await _context.Moves
            .Include(x => x.Addresses) // Include related Addresses
            .Include(x => x.Amenities) // Include Amenities navigation property
            .FirstOrDefaultAsync(x => x.Id == id); // Find the entity by Id

            if (privateMove == null)
            {
                return null;
            }

            // Map the entity to its corresponding DTO
            return _mapper.Map<PrivateMoveDto>(privateMove);
        }

        public async Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto)
        {
            var privateMove = _mapper.Map<Models.Move>(privateMoveDto);

            // Add the mapped entity to the context and save
            _context.Moves.Add(privateMove);
            await _context.SaveChangesAsync();

            // Optionally, map the saved entity back to a DTO for return
            return _mapper.Map<PrivateMoveDto>(privateMove);
        }

    }
}
