using AutoMapper;
using FinalProject.Models;

namespace FinalProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /*----------Private Moves mappings--------------*/
            CreateMap<Move, PrivateMoveDto>()
                .ForMember(dest => dest.MoveFromAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveFrom")))
                .ForMember(dest => dest.MoveToAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveTo")));

            CreateMap<PrivateMoveDto, Move>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => new List<Address>
             {
                new()
                {
                    Street = src.MoveFromAddress.Street,
                    Type = "MoveFrom" // Custom label for the address type
                },
                new()
                {
                    Street = src.MoveToAddress.Street,
                    Type = "MoveTo" // Custom label for the address type
                }
             }));

            /*_______________Business Moves mapping -----------------*/
            CreateMap<Move, BusinessMoveDto>()
                .ForMember(dest => dest.MoveFromAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveFrom")))
                .ForMember(dest => dest.MoveToAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveTo")));

            CreateMap<BusinessMoveDto, Move>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => new List<Address>
             {
                new()
                {
                    Street = src.MoveFromAddress.Street,
                    Type = "MoveFrom" // Custom label for the address type
                },
                new()
                {
                    Street = src.MoveToAddress.Street,
                    Type = "MoveTo" // Custom label for the address type
                }
             }));

            //_______________Address mapping______________

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();

            //____________________Amenities mapping__________________

            CreateMap<AmenitiesDto, Amenities>();
            //.ForMember(dest => dest.ElevatorFromAddress, opt => opt.MapFrom(src => src.ElevatorFromAddress))
            //.ForMember(dest => dest.ElevatorToAddress, opt => opt.MapFrom(src => src.ElevatorToAddress))
            //.ForMember(dest => dest.FurnitureLiftFromAddress, opt => opt.MapFrom(src => src.FurnitureLiftFromAddress))
            //.ForMember(dest => dest.FurnitureLiftToAddress, opt => opt.MapFrom(src => src.FurnitureLiftToAddress));

            CreateMap<Amenities, AmenitiesDto>();
                //.ForMember(dest => dest.ElevatorFromAddress, opt => opt.MapFrom(src => src.ElevatorFromAddress))
                //.ForMember(dest => dest.ElevatorToAddress, opt => opt.MapFrom(src => src.ElevatorToAddress))
                //.ForMember(dest => dest.FurnitureLiftFromAddress, opt => opt.MapFrom(src => src.FurnitureLiftFromAddress))
                //.ForMember(dest => dest.FurnitureLiftToAddress, opt => opt.MapFrom(src => src.FurnitureLiftToAddress));

            //____________________Floor mapping__________________

            CreateMap<Floor, FloorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SortOrder, opt => opt.MapFrom(src => src.SortOrder))
                .ForMember(dest => dest.MoveId, opt => opt.MapFrom(src => src.MoveId));

            CreateMap<FloorDto, Floor>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SortOrder, opt => opt.MapFrom(src => src.SortOrder))
                .ForMember(dest => dest.MoveId, opt => opt.MapFrom(src => src.MoveId));

            CreateMap<FloorType, FloorTypeDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<FloorTypeDto, FloorType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            //____________________Room mapping__________________

            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FloorId, opt => opt.MapFrom(src => src.FloorId));
           
            CreateMap<RoomDto, Room>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FloorId, opt => opt.MapFrom(src => src.FloorId));

            CreateMap<RoomType, RoomTypeDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            
            CreateMap<RoomTypeDto, RoomType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            //____________________Inventory mapping__________________

            CreateMap<InventoryType, InventoryTypeDto>();
            CreateMap<InventoryTypeDto, InventoryType>();

            CreateMap<Inventory, InventoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.Volume))
                .ForMember(dest => dest.Special, opt => opt.MapFrom(src => src.Special))
                .ForMember(dest => dest.Disassemble, opt => opt.MapFrom(src => src.Disassemble))
                .ForMember(dest => dest.Assemble, opt => opt.MapFrom(src => src.Assemble))
                .ForMember(dest => dest.NotIncluded, opt => opt.MapFrom(src => src.NotIncluded))
                // Explicitly ignore navigation properties to prevent them from being mapped
                .ForMember(dest => dest.toBeWrapped, opt => opt.MapFrom(src => src.toBeWrapped));

            CreateMap<InventoryDto, Inventory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.Volume))
                .ForMember(dest => dest.Special, opt => opt.MapFrom(src => src.Special))
                .ForMember(dest => dest.Disassemble, opt => opt.MapFrom(src => src.Disassemble))
                .ForMember(dest => dest.Assemble, opt => opt.MapFrom(src => src.Assemble))
                .ForMember(dest => dest.NotIncluded, opt => opt.MapFrom(src => src.NotIncluded))
                .ForMember(dest => dest.toBeWrapped, opt => opt.MapFrom(src => src.toBeWrapped));
            // Explicitly ignore navigation properties to prevent them from being mapped
            // .ForMember(dest => dest.toBeWrapped, opt => opt.Ignore());

            CreateMap<Wrapping, WrappingDto>()
                .ForMember(dest => dest.ShouldBeWrapped, opt => opt.MapFrom(src => src.ShouldBeWrapped))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note));
            CreateMap<WrappingDto, Wrapping>()
                .ForMember(dest => dest.ShouldBeWrapped, opt => opt.MapFrom(src => src.ShouldBeWrapped))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note));


        }

    }
}
