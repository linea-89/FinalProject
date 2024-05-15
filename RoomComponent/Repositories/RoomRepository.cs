using FinalProject.Data;
using FinalProject.RoomComponent.Models.Domain;
using FinalProject.Shared.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RoomComponent.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly FinalProjectContext _context;
        public RoomRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<RoomType> CreateRoomTypeAsync(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            return roomType;
        }

        public async Task<List<RoomType>> GetRoomTypesAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }
    }
}
