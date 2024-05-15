using FinalProject.FloorComponent.Models.Domain;
using FinalProject.Shared.Models.Domain;

namespace FinalProject.FloorComponent.Repositories
{
    public interface IFloorRepository
    {
        public Task<Floor> AddFloorAsync(Floor floor);
        public Task<List<Floor>> GetFloorsAsync();
        public Task<FloorType> CreateFloorTypeAsync(FloorType floorType);
        public Task<List<FloorType>> GetFloorTypesAsync();
    }
}
