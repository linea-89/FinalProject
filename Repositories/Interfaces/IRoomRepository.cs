using FinalProject.RoomComponent.Models.Domain;
using FinalProject.Shared.Models.Domain;

namespace FinalProject.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        public Task<Room> AddRoomAsync(Room room);

        public Task<List<Room>> GetRoomsAsync();
        public Task<RoomType> CreateRoomTypeAsync(RoomType roomType);
        public Task<List<RoomType>> GetRoomTypesAsync();


    }
}
