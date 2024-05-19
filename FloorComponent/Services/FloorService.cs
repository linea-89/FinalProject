using FinalProject.FloorComponent.Dto;
using FinalProject.Shared.RepositoryInterfaces;
using FinalProject.Shared.MapperInterfaces;

namespace FinalProject.FloorComponent.Services
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _repository;
        private readonly IFloorMapper _mapper;

        public FloorService(IFloorRepository repository, IFloorMapper floorMapper)
        {
            _repository = repository;
            _mapper = floorMapper;
        }

        public async Task<FloorDto> AddFloor(FloorDto floorDto)
        {
            var floor = _mapper.MapAddedFloor(floorDto);
            _ = await _repository.AddFloorAsync(floor);

            return _mapper.MapFloorResponse(floor);
        }

        public async Task<List<FloorDto>> GetFloors(int moveId)
        {
            var floors = await _repository.GetFloorsAsync(moveId);
            var mappedResult = _mapper.MapFloorsResponse(floors);

            return mappedResult;
        }

        public async Task<FloorDto> GetFloorById(int moveId, int id)
        {
            var floor = await _repository.GetFloorByIdAsync(moveId, id);

            if (floor == null)
            {
                return null;
            }

            var mappedResult = _mapper.MapFloorResponse(floor);

            return mappedResult;
        }

        public async Task<FloorTypeDto> CreateFloorType(FloorTypeDto floorTypeDto)
        {
            var floorType = _mapper.MapCreatedFloorType(floorTypeDto);
            _ = await _repository.CreateFloorTypeAsync(floorType);

            return _mapper.MapFloorTypeResponse(floorType);
        }

        public async Task<List<FloorTypeDto>> GetFloorTypes()
        {
            var floorTypes = await _repository.GetFloorTypesAsync();
            var mappedResult = _mapper.MapFloorTypeRespons(floorTypes);

            return mappedResult;
        }
    }
}
