using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Floor
{
    public interface IFloorService
    {
        public Task<FloorDto> AddFloor(FloorDto floorDto);

        public ActionResult<List<FloorDto>> GetFloors();
        public Task<FloorDto> GetFloorByIdAsync(int id);
        public Task<FloorTypeDto> createFloorType(FloorTypeDto floorTypeDto);
    }
}
