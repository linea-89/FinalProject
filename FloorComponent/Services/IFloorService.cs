using FinalProject.FloorComponent.Dto;

namespace FinalProject.FloorComponent.Services
{
    public interface IFloorService
    {
        public Task<FloorDto> AddFloor(FloorDto floorDto);
        public Task<List<FloorDto>> GetFloors(int moveId);
        public Task<FloorDto> GetFloorById(int moveId, int id);
        public Task<FloorTypeDto> CreateFloorType(FloorTypeDto floorTypeDto);
        public Task<List<FloorTypeDto>> GetFloorTypes();

    }
}
