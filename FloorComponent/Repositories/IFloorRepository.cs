using FinalProject.FloorComponent.Models.Dto;
using FinalProject.Shared.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.FloorComponent.Repositories
{
    public interface IFloorRepository
    {
        public Task<Floor> AddAsync(Floor floor);
        public Task<List<Floor>> GetFloors();
        ////public Task<List<Floor>> GetAllAsync();
        ////public Task<Floor> GetByIdAsync(int id);
    }
}
