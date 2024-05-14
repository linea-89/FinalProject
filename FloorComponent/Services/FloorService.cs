using AutoMapper;
using FinalProject.Data;
using Microsoft.AspNetCore.Mvc;
using FinalProject.FloorComponent.Models.Domain;
using FinalProject.FloorComponent.Models.Dto;
using FinalProject.Shared.Models.Domain;

namespace FinalProject.FloorComponent.Services
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
            var floor = _mapper.Map<Floor>(floorDto);

            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();

            return _mapper.Map<FloorDto>(floor);
        }

        public ActionResult<List<FloorDto>> GetFloors(int moveId)
        {
            var floors = _context.Floors.ToList();

            // Map the result to the PrivateMoveDto list
            var result = floors
                .Select(result => _mapper.Map<FloorDto>(result))
                .Where(x => x.MoveId == moveId)
                .ToList(); // Materialize the query into a list

            return result;
        }

        public ActionResult<FloorDto> GetFloorByIdAsync(int moveId, int id)
        {
            var floor = _context.Floors.ToList();
            //.FirstOrDefaultAsync(x => x.Id == id); // Find the entity by Id

            var result = floor.Select(result => _mapper.Map<FloorDto>(result))
                .Where(x => x.MoveId == moveId).FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            // Map the entity to its corresponding DTO
            //  return _mapper.Map<FloorDto>(floor);
            return result;
        }

        public async Task<FloorTypeDto> CreateFloorType(FloorTypeDto floorTypeDto)
        {
            var floorType = _mapper.Map<FloorType>(floorTypeDto);

            _context.FloorTypes.Add(floorType);
            await _context.SaveChangesAsync();

            return _mapper.Map<FloorTypeDto>(floorType);
        }

        public ActionResult<List<FloorTypeDto>> GetFloorTypes()
        {
            var floorTypes = _context.FloorTypes.ToList();

            // Map the result to the PrivateMoveDto list
            var result = floorTypes
                .Select(result => _mapper.Map<FloorTypeDto>(result))
                .ToList(); // Materialize the query into a list

            return result;
        }

    }
}
