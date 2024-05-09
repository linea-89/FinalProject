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

            /*------------Business Moves mapping -----------------*/
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

            /*------------Other mappings----------------*/

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();


            CreateMap<AmenitiesDto, Amenities>()
                .ForMember(dest => dest.ElevatorFromAddress, opt => opt.MapFrom(src => src.ElevatorFromAddress))
                .ForMember(dest => dest.ElevatorToAddress, opt => opt.MapFrom(src => src.ElevatorToAddress))
                .ForMember(dest => dest.FurnitureLiftFromAddress, opt => opt.MapFrom(src => src.FurnitureLiftFromAddress))
                .ForMember(dest => dest.FurnitureLiftToAddress, opt => opt.MapFrom(src => src.FurnitureLiftToAddress));

            CreateMap<Amenities, AmenitiesDto>()
                .ForMember(dest => dest.ElevatorFromAddress, opt => opt.MapFrom(src => src.ElevatorFromAddress))
                .ForMember(dest => dest.ElevatorToAddress, opt => opt.MapFrom(src => src.ElevatorToAddress))
                .ForMember(dest => dest.FurnitureLiftFromAddress, opt => opt.MapFrom(src => src.FurnitureLiftFromAddress))
                .ForMember(dest => dest.FurnitureLiftToAddress, opt => opt.MapFrom(src => src.FurnitureLiftToAddress));

            CreateMap<Floor, FloorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SortOrder, opt => opt.MapFrom(src => src.SortOrder))
                .ForMember(dest => dest.MoveId, opt => opt.MapFrom(src => src.MoveId));

            CreateMap<FloorDto, Floor>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SortOrder, opt => opt.MapFrom(src => src.SortOrder))
                .ForMember(dest => dest.MoveId, opt => opt.MapFrom(src => src.MoveId));

            CreateMap<Floor, FloorTypeDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


            CreateMap<FloorTypeDto, Floor>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));



        }

    }
}
