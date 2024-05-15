using AutoMapper;
using FinalProject.FloorComponent.Models.Domain;
using FinalProject.FloorComponent.Models.Dto;
using FinalProject.Shared.Models.Domain;
using FinalProject.FloorComponent.Repositories;

namespace FinalProject.FloorComponent.Services
{
    public class FloorService : IFloorService
    {
        private readonly IMapper _mapper;
        private readonly IFloorRepository _repository;

        public FloorService(IMapper mapper, IFloorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<FloorDto> AddFloor(FloorDto floorDto)
        {
            var floor = _mapper.Map<Floor>(floorDto);
            _ = await _repository.AddFloorAsync(floor);

            return _mapper.Map<FloorDto>(floor);
        }

        public async Task<List<FloorDto>> GetFloors(int moveId)
        {
            var floors = await _repository.GetFloorsAsync();

            var result = floors
                .Select(result => _mapper.Map<FloorDto>(result))
                .Where(x => x.MoveId == moveId)
                .ToList();

            return result;
        }

        public async Task<FloorDto> GetFloorById(int moveId, int id)
        {
            var floor = await _repository.GetFloorsAsync();

            var result = floor.Select(result => _mapper.Map<FloorDto>(result))
                .Where(x => x.MoveId == moveId).FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<FloorTypeDto> CreateFloorType(FloorTypeDto floorTypeDto)
        {
            var floorType = _mapper.Map<FloorType>(floorTypeDto);
            _ = await _repository.CreateFloorTypeAsync(floorType);

            return _mapper.Map<FloorTypeDto>(floorType);
        }

        public async Task<List<FloorTypeDto>> GetFloorTypes()
        {
            var floorTypes = await _repository.GetFloorTypesAsync();

            var result = floorTypes
                .Select(result => _mapper.Map<FloorTypeDto>(result))
                .ToList();

            return result;
        }
    }
}
