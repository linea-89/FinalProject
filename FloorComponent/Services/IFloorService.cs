using FinalProject.FloorComponent.Models.Domain;
using FinalProject.FloorComponent.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.FloorComponent.Services
{
    public interface IFloorService
    {
        public Task<FloorDto> AddFloor(FloorDto floorDto);
        public Task<List<FloorDto>> GetFloorsAsync(int moveId);
        public ActionResult<FloorDto> GetFloorByIdAsync(int moveId, int id);
        public Task<FloorTypeDto> CreateFloorType(FloorTypeDto floorTypeDto);
        public ActionResult<List<FloorTypeDto>> GetFloorTypes();

    }
}
