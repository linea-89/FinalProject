using AutoMapper;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services.BusinessMove;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.Move
{
    public class BusinessMoveService : IBusinessMoveService
    {
        private readonly FinalProjectContext _context;
        private readonly IMapper _mapper;

        public BusinessMoveService(FinalProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActionResult<List<BusinessMoveDto>> GetBusinessMoves()
        {
            // Load the related entities explicitly using .Include and map to the DTO
            var businessMoves = _context.Moves
                .Include(pm => pm.Addresses) // Include related Addresses collection
                .Include(pm => pm.Amenities)
                .Where(pm => pm.Type == "BusinessMove")/// Include the Amenities navigation property
                .ToList(); // Ensure query execution to fetch the data

            // Map the result to the PrivateMoveDto list
            var businessMoveDtos = businessMoves
                .Select(businessMove => _mapper.Map<BusinessMoveDto>(businessMove))
                .ToList(); // Materialize the query into a list

            return businessMoveDtos;
        }

        public async Task<BusinessMoveDto> GetBusinessMoveByIdAsync(int id)
        {
            var businessMove = await _context.Moves
            .Include(pm => pm.Addresses) // Include related Addresses
            .Include(pm => pm.Amenities) // Include Amenities navigation property
            .FirstOrDefaultAsync(pm => pm.Id == id); // Find the entity by Id

            if (businessMove == null)
            {
                return null;
            }

            // Map the entity to its corresponding DTO
            return _mapper.Map<BusinessMoveDto>(businessMove);
        }


        public async Task<BusinessMoveDto> CreateBusinessMoveAsync(BusinessMoveDto businessMoveDto)
        {
            var businessMove = _mapper.Map<Models.Move>(businessMoveDto);

            // Add the mapped entity to the context and save
            _context.Moves.Add(businessMove);
            await _context.SaveChangesAsync();

            // Optionally, map the saved entity back to a DTO for return
            return _mapper.Map<BusinessMoveDto>(businessMove);
        }


    }
}
