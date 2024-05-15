using FinalProject.RoomComponent.Models.Domain;
using FinalProject.Shared.Models.Domain;

namespace FinalProject.RoomComponent.Repositories
{
    public interface IRoomRepository
    {
        public Task<Room> AddRoomAsync(Room room);

        public Task<List<Room>> GetRoomsAsync();
        public Task<RoomType> CreateRoomTypeAsync(RoomType roomType);
        public Task<List<RoomType>> GetRoomTypesAsync();


    }
}
