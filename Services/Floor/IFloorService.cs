using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Floor
{
    public interface IFloorService
    {
        public Task<FloorDto> AddFloor(FloorDto floorDto);
    }
}
