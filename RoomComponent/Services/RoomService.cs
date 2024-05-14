using AutoMapper;
using FinalProject.Data;
using FinalProject.RoomComponent.Models.Domain;
using FinalProject.RoomComponent.Models.Dto;
using FinalProject.Shared.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace FinalProject.RoomComponent.Services
{
    public class RoomService : IRoomService
    {
        private readonly ILogger<RoomService> _logger;
        private readonly IMapper _mapper;
        private readonly FinalProjectContext _context;

        public RoomService(ILogger<RoomService> logger, IMapper mapper, FinalProjectContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<RoomDto> AddRoom(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return _mapper.Map<RoomDto>(room);
        }

        public ActionResult<List<RoomDto>> GetRooms(int floorId)
        {
            var rooms = _context.Rooms.ToList();

            // Map the result to the PrivateMoveDto list
            var result = rooms
                .Select(result => _mapper.Map<RoomDto>(result))
                .Where(x => x.FloorId == floorId)
                .ToList(); // Materialize the query into a list

            return result;
        }

        public ActionResult<RoomDto> GetRoomById(int floorId, int id)
        {
            var room = _context.Rooms.ToList();
            //.FirstOrDefaultAsync(x => x.Id == id); // Find the entity by Id

            var result = room.Select(result => _mapper.Map<RoomDto>(result))
                .Where(x => x.FloorId == floorId).FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            // Map the entity to its corresponding DTO
            return result;
        }

        public async Task<RoomTypeDto> CreateRoomType(RoomTypeDto roomTypeDto)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeDto);

            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            return _mapper.Map<RoomTypeDto>(roomType);
        }

        public ActionResult<List<RoomTypeDto>> GetRoomTypes()
        {
            var roomTypes = _context.RoomTypes.ToList();

            // Map the result to the PrivateMoveDto list
            var result = roomTypes
                .Select(result => _mapper.Map<RoomTypeDto>(result))
                .ToList(); // Materialize the query into a list

            return result;
        }

    }
}
