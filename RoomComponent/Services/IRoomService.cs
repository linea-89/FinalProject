using FinalProject.RoomComponent.Models.Dto;

namespace FinalProject.RoomComponent.Services
{
    public interface IRoomService
    {
        public Task<RoomDto> AddRoom(RoomDto roomDto);
        public Task<List<RoomDto>> GetRooms(int floorId);
        public Task<RoomDto> GetRoomById(int floorId, int id);
        public Task<RoomTypeDto> CreateRoomType(RoomTypeDto roomTypeDto);
        public Task<List<RoomTypeDto>> GetRoomTypes();

    }
}
