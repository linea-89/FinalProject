using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models.RoomModels;
using FinalProject.Shared.ModelInterfaces;
using FinalProject.Shared.RepositoryInterfaces;


namespace FinalProject.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly FinalProjectContext _context;
        public RoomRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<IRoom> AddRoomAsync(IRoom room)
        {
            var roomEntity = room as Room;
            _ = _context.Rooms.Add(roomEntity);
            await _context.SaveChangesAsync();

            return roomEntity;
        }

        public async Task<List<IRoom>> GetRoomsAsync(int floorId)
        {
            return await _context.Rooms
                .Where(x => x.FloorId == floorId)
                .ToListAsync<IRoom>();
        }

        public async Task<IRoom> GetRoomByIdAsync(int floorId, int id)
        {
            var room = await _context.Rooms
                .Where(x => x.FloorId == floorId && x.Id == id)
                .FirstOrDefaultAsync();

            return room;
        }

        public async Task<IRoomType> CreateRoomTypeAsync(IRoomType roomType)
        {
            var roomTypeEntity = roomType as RoomType;
            _context.RoomTypes.Add(roomTypeEntity);
            await _context.SaveChangesAsync();

            return roomTypeEntity;
        }

        public async Task<List<IRoomType>> GetRoomTypesAsync()
        {
            return await _context.RoomTypes.ToListAsync<IRoomType>();
        }

    }
}
