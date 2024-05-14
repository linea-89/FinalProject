using FinalProject.RoomComponent.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.RoomComponent.Services
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
