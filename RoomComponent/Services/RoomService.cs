using AutoMapper;
using FinalProject.Repositories.Interfaces;
using FinalProject.RoomComponent.Models.Domain;
using FinalProject.RoomComponent.Models.Dto;
using FinalProject.Shared.Models.Domain;

namespace FinalProject.RoomComponent.Services
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _repository;

        public RoomService(IMapper mapper, IRoomRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<RoomDto> AddRoom(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            _ = await _repository.AddRoomAsync(room);

            return _mapper.Map<RoomDto>(room);
        }

        public async Task<List<RoomDto>> GetRooms(int floorId)
        {
            var rooms = await _repository.GetRoomsAsync();

            var result = rooms
                .Select(result => _mapper.Map<RoomDto>(result))
                .Where(x => x.FloorId == floorId)
                .ToList();

            return result;
        }

        public async Task<RoomDto> GetRoomById(int floorId, int id)
        {
            var room = await _repository.GetRoomsAsync();

            var result = room.Select(result => _mapper.Map<RoomDto>(result))
                .Where(x => x.FloorId == floorId).FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<RoomTypeDto> CreateRoomType(RoomTypeDto roomTypeDto)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeDto);
            _ = await _repository.CreateRoomTypeAsync(roomType);

            return _mapper.Map<RoomTypeDto>(roomType);
        }

        public async Task<List<RoomTypeDto>> GetRoomTypes()
        {
            var roomTypes = await _repository.GetRoomTypesAsync();

            var result = roomTypes
                .Select(result => _mapper.Map<RoomTypeDto>(result))
                .ToList();

            return result;
        }

    }
}
