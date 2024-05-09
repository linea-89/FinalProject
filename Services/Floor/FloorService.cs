using AutoMapper;
using FinalProject.Data;
using FinalProject.Models;

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
    }
}
