using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.RepositoryInterfaces
{
    public interface IRoomRepository
    {
        public Task<IRoom> AddRoomAsync(IRoom room);
        public Task<List<IRoom>> GetRoomsAsync(int floorId);
        public Task<IRoom> GetRoomByIdAsync(int floorId, int id);
        public Task<IRoomType> CreateRoomTypeAsync(IRoomType roomType);
        public Task<List<IRoomType>> GetRoomTypesAsync();


    }
}
