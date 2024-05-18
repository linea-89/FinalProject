using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.RepositoryInterfaces
{
    public interface IFloorRepository
    {
        public Task<IFloor> AddFloorAsync(IFloor floor);
        public Task<List<IFloor>> GetFloorsAsync(int moveId);
        public Task<IFloor> GetFloorByIdAsync(int moveId, int id);
        public Task<IFloorType> CreateFloorTypeAsync(IFloorType floorType);
        public Task<List<IFloorType>> GetFloorTypesAsync();
    }
}
