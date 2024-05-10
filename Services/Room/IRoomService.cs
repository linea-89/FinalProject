using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Room
{
    public interface IRoomService
    {
        public Task<RoomDto> AddRoom(RoomDto roomDto);
        public ActionResult<List<RoomDto>> GetRooms(int floorId);
        public ActionResult<RoomDto> GetRoomById(int floorId, int id);
        public Task<RoomTypeDto> CreateRoomType(RoomTypeDto roomTypeDto);
        public ActionResult<List<RoomTypeDto>> GetRoomTypes();

    }
}
