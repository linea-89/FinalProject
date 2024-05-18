using FinalProject.Models.FloorModels;
using FinalProject.FloorComponent.Dto;
using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.MapperInterfaces
{
    public interface IFloorMapper
    {
        public Floor MapAddedFloor(FloorDto floorDto);
        public List<FloorDto> MapFloorsResponse(List<IFloor> floors);
        public FloorDto MapFloorResponse(IFloor floor);
        public FloorType MapCreatedFloorType(FloorTypeDto floorTypeDto);
        public FloorTypeDto MapFloorTypeResponse(IFloorType floorType);
        public List<FloorTypeDto> MapFloorTypeRespons(List<IFloorType> floorTypes);
    }
}