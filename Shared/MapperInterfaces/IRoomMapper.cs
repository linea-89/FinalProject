using FinalProject.Models.RoomModels;
using FinalProject.RoomComponent.Dto;
using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.MapperInterfaces
{
    public interface IRoomMapper
    {
        public Room MapAddedRoom(RoomDto roomDto);
        public List<RoomDto> MapRoomsRespons(List<IRoom> rooms);
        public RoomDto MapRoomResponse(IRoom room);
        public RoomType MapCreatedRoomType(RoomTypeDto roomTypeDto);
        public RoomTypeDto MapRoomTypeResponse(IRoomType roomType);
        public List<RoomTypeDto> MapRoomTypeRespons(List<IRoomType> roomTypes);
    }
}
