using FinalProject.FloorComponent.Dto;
using FinalProject.Shared.RepositoryInterfaces;
using FinalProject.Shared.MapperInterfaces;

namespace FinalProject.FloorComponent.Services
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _repository;
        private readonly IFloorMapper _floorMapper;

        public FloorService(IFloorRepository repository, IFloorMapper floorMapper)
        {
            _repository = repository;
            _floorMapper = floorMapper;
        }

        public async Task<FloorDto> AddFloor(FloorDto floorDto)
        {
            var floor = _floorMapper.MapAddedFloor(floorDto);
            _ = await _repository.AddFloorAsync(floor);

            return _floorMapper.MapFloorResponse(floor);
        }

        public async Task<List<FloorDto>> GetFloors(int moveId)
        {
            var floors = await _repository.GetFloorsAsync(moveId);
            var mappedResult = _floorMapper.MapFloorsResponse(floors);

            return mappedResult;
        }

        public async Task<FloorDto> GetFloorById(int moveId, int id)
        {
            var floor = await _repository.GetFloorByIdAsync(moveId, id);

            if (floor == null)
            {
                return null;
            }

            var mappedResult = _floorMapper.MapFloorResponse(floor);

            return mappedResult;
        }

        public async Task<FloorTypeDto> CreateFloorType(FloorTypeDto floorTypeDto)
        {
            var floorType = _floorMapper.MapCreatedFloorType(floorTypeDto);
            _ = await _repository.CreateFloorTypeAsync(floorType);

            return _floorMapper.MapFloorTypeResponse(floorType);
        }

        public async Task<List<FloorTypeDto>> GetFloorTypes()
        {
            var floorTypes = await _repository.GetFloorTypesAsync();
            var mappedResult = _floorMapper.MapFloorTypeRespons(floorTypes);

            return mappedResult;
        }
    }
}
