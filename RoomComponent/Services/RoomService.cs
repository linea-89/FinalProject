using FinalProject.RoomComponent.Dto;
using FinalProject.Shared.RepositoryInterfaces;
using FinalProject.Shared.MapperInterfaces;

namespace FinalProject.RoomComponent.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IRoomMapper _roomMapper;

        public RoomService(IRoomRepository repository, IRoomMapper roomMapper)
        {
            _repository = repository;
            _roomMapper = roomMapper;
        }

        public async Task<RoomDto> AddRoom(RoomDto roomDto)
        {
            var room = _roomMapper.MapAddedRoom(roomDto);
            _ = await _repository.AddRoomAsync(room);

            return _roomMapper.MapRoomResponse(room);
        }

        public async Task<List<RoomDto>> GetRooms(int floorId)
        {
            var rooms = await _repository.GetRoomsAsync(floorId);
            var mappedResult = _roomMapper.MapRoomsRespons(rooms);

            return mappedResult;
        }

        public async Task<RoomDto> GetRoomById(int floorId, int id)
        {
            var room = await _repository.GetRoomByIdAsync(floorId, id);

            if (room == null)
            {
                return null;
            }

            var mappedResult = _roomMapper.MapRoomResponse(room);

            return mappedResult;
        }

        public async Task<RoomTypeDto> CreateRoomType(RoomTypeDto roomTypeDto)
        {
            var roomType = _roomMapper.MapCreatedRoomType(roomTypeDto);
            _ = await _repository.CreateRoomTypeAsync(roomType);

            return _roomMapper.MapRoomTypeResponse(roomType);
        }

        public async Task<List<RoomTypeDto>> GetRoomTypes()
        {
            var roomTypes = await _repository.GetRoomTypesAsync();
            var mappedResult = _roomMapper.MapRoomTypeRespons(roomTypes);

            return mappedResult;
        }

    }
}
