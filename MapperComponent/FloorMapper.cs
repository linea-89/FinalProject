using AutoMapper;
using FinalProject.FloorComponent.Dto;
using FinalProject.Models.FloorModels;
using FinalProject.Shared.ModelInterfaces;
using FinalProject.Shared.MapperInterfaces;

namespace FinalProject.MapperComponent
{
    public class FloorMapper : IFloorMapper
    {
        public readonly IMapper _mapper;

        public FloorMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Floor MapAddedFloor(FloorDto floorDto)
        {
            return _mapper.Map<Floor>(floorDto);
        }

        public FloorDto MapFloorResponse(IFloor floor)
        {
            return _mapper.Map<FloorDto>(floor);
        }

        public List<FloorDto> MapFloorsResponse(List<IFloor> floors)
        {
            return floors
                .Select(floor => _mapper
                .Map<FloorDto>(floor))
                .ToList();
        }

        public FloorType MapCreatedFloorType(FloorTypeDto floorTypeDto)
        {
            return _mapper.Map<FloorType>(floorTypeDto);
        }

        public FloorTypeDto MapFloorTypeResponse(IFloorType floorType)
        {
            return _mapper.Map<FloorTypeDto>(floorType);
        }

        public List<FloorTypeDto> MapFloorTypeRespons(List<IFloorType> floorTypes)
        {
            return floorTypes
                .Select(floorType => _mapper
                .Map<FloorTypeDto>(floorType))
                .ToList();
        }
    }
}
