using AutoMapper;
using FinalProject.Models.FloorModels;
using FinalProject.Models.InventoryModels;
using FinalProject.Models.MoveModels;
using FinalProject.Models.RoomModels;
using FinalProject.MoveComponent.Dto;
using FinalProject.RoomComponent.Dto;
using FinalProject.FloorComponent.Dto;
using FinalProject.InventoryComponent.Dto;

namespace FinalProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //_______________Move mappings_______________
            CreateMap<Move, PrivateMoveDto>()
                .ForMember(dest => dest.MoveFromAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveFrom")))
                .ForMember(dest => dest.MoveToAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveTo")));

            CreateMap<PrivateMoveDto, Move>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => new List<Address>
             {
                new()
                {
                    Street = src.MoveFromAddress.Street,
                    ZipCode = src.MoveFromAddress.ZipCode,
                    City = src.MoveFromAddress.City,
                    Country = src.MoveFromAddress.Country,
                    Type = "MoveFrom" // Custom label for the address type
                },
                new()
                {
                    Street = src.MoveToAddress.Street,
                    ZipCode = src.MoveToAddress.ZipCode,
                    City = src.MoveToAddress.City,
                    Country = src.MoveToAddress.Country,
                    Type = "MoveTo" // Custom label for the address type
                }
             }));

            //_______________Business Moves mapping___________
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

            CreateMap<Address, AddressDto>().ReverseMap();

            //____________________Amenities mapping__________________

            CreateMap<AmenitiesDto, Amenities>().ReverseMap();

            //____________________Floor mapping__________________

            CreateMap<Floor, FloorDto>().ReverseMap();
            CreateMap<FloorType, FloorTypeDto>().ReverseMap();

            //____________________Room mapping__________________

            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();

            //____________________Inventory mapping__________________

            CreateMap<Inventory, InventoryDto>().ReverseMap();
            CreateMap<InventoryType, InventoryTypeDto>().ReverseMap();
            CreateMap<Wrapping, WrappingDto>().ReverseMap();

        }
    }
}
