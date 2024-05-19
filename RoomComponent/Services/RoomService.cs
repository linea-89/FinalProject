using FinalProject.RoomComponent.Dto;
using FinalProject.Shared.RepositoryInterfaces;
using FinalProject.Shared.MapperInterfaces;

namespace FinalProject.RoomComponent.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IRoomMapper _mapper;

        public RoomService(IRoomRepository repository, IRoomMapper roomMapper)
        {
            _repository = repository;
            _mapper = roomMapper;
        }

        public async Task<RoomDto> AddRoom(RoomDto roomDto)
        {
            var room = _mapper.MapAddedRoom(roomDto);
            _ = await _repository.AddRoomAsync(room);

            return _mapper.MapRoomResponse(room);
        }

        public async Task<List<RoomDto>> GetRooms(int floorId)
        {
            var rooms = await _repository.GetRoomsAsync(floorId);
            var mappedResult = _mapper.MapRoomsRespons(rooms);

            return mappedResult;
        }

        public async Task<RoomDto> GetRoomById(int floorId, int id)
        {
            var room = await _repository.GetRoomByIdAsync(floorId, id);

            if (room == null)
            {
                return null;
            }

            var mappedResult = _mapper.MapRoomResponse(room);

            return mappedResult;
        }

        public async Task<RoomTypeDto> CreateRoomType(RoomTypeDto roomTypeDto)
        {
            var roomType = _mapper.MapCreatedRoomType(roomTypeDto);
            _ = await _repository.CreateRoomTypeAsync(roomType);

            return _mapper.MapRoomTypeResponse(roomType);
        }

        public async Task<List<RoomTypeDto>> GetRoomTypes()
        {
            var roomTypes = await _repository.GetRoomTypesAsync();
            var mappedResult = _mapper.MapRoomTypeRespons(roomTypes);

            return mappedResult;
        }

    }
}
