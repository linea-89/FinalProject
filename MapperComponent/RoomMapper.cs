using AutoMapper;
using FinalProject.Models.RoomModels;
using FinalProject.RoomComponent.Dto;
using FinalProject.Shared.MapperInterfaces;
using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.MapperComponent
{
    public class RoomMapper :IRoomMapper
    {
        private readonly IMapper _mapper;

        public RoomMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Room MapAddedRoom(RoomDto roomDto)
        {
            return _mapper.Map<Room>(roomDto);
        }

        public List<RoomDto> MapRoomsRespons(List<IRoom> rooms)
        {
            return rooms
                .Select(room => _mapper
                .Map<RoomDto>(room))
                .ToList();
        }

        public RoomDto MapRoomResponse(IRoom room)
        {
            return _mapper.Map<RoomDto>(room);
        }

        public RoomType MapCreatedRoomType(RoomTypeDto roomTypeDto)
        {
            return _mapper.Map<RoomType>(roomTypeDto);
        }

        public RoomTypeDto MapRoomTypeResponse(IRoomType roomType)
        {
            return _mapper.Map<RoomTypeDto>(roomType);
        }

        public List<RoomTypeDto> MapRoomTypeRespons(List<IRoomType> roomTypes)
        {
            return roomTypes.Select(roomType => _mapper.Map<RoomTypeDto>(roomType)).ToList();
     
        }

        
    }
}
