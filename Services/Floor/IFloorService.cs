using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Floor
{
    public interface IFloorService
    {
        public Task<FloorDto> AddFloor(FloorDto floorDto);

        public ActionResult<List<FloorDto>> GetFloors(int moveId);
        public ActionResult<FloorDto> GetFloorByIdAsync(int moveId, int id);
        public Task<FloorTypeDto> CreateFloorType(FloorTypeDto floorTypeDto);
        public ActionResult<List<FloorTypeDto>> GetFloorTypes();

    }
}
