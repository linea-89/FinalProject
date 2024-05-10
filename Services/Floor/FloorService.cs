using AutoMapper;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace FinalProject.Services.Floor
{
    public class FloorService : IFloorService
    {
        private readonly ILogger<FloorService> _logger;
        private readonly IMapper _mapper;
        private readonly FinalProjectContext _context;

        public FloorService(ILogger<FloorService> logger, IMapper mapper, FinalProjectContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<FloorDto> AddFloor(FloorDto floorDto)
        {
            var floor = _mapper.Map<Models.Floor>(floorDto);

            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();

            return _mapper.Map<FloorDto>(floor);
        }

        public ActionResult<List<FloorDto>> GetFloors()
        {
            var floors = _context.Floors.ToList();

            // Map the result to the PrivateMoveDto list
            var result = floors
                .Select(result => _mapper.Map<FloorDto>(result))
                .ToList(); // Materialize the query into a list

            return result;
        }

        public async Task<FloorTypeDto> createFloorType(FloorTypeDto floorTypeDto)
        {
            var floorType = _mapper.Map<Models.FloorType>(floorTypeDto);

            _context.FloorTypes.Add(floorType);
            await _context.SaveChangesAsync();

            return _mapper.Map<FloorTypeDto>(floorType);
        }

        public async Task<FloorDto> GetFloorByIdAsync(int id)
        {
            var floor = await _context.Floors
            .FirstOrDefaultAsync(x => x.Id == id); // Find the entity by Id

            if (floor == null)
            {
                return null;
            }

            // Map the entity to its corresponding DTO
            return _mapper.Map<FloorDto>(floor);
        }
    }
}
