using AutoMapper;
using FinalProject.Models;

namespace FinalProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Test, TestDto>();
            CreateMap<TestDto, Test>();

            /*----------Private Moves mappings--------------*/
            CreateMap<Move, PrivateMoveDto>();
                //.ForMember(dest => dest.MoveFromAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveFrom")))
                //.ForMember(dest => dest.MoveToAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveTo")));

            CreateMap<PrivateMoveDto, Move>()
             .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => new List<Address>
             {
                new Address
                {
                    Street = src.MoveFromAddress.Street,
                    //Type = "MoveFrom" // Custom label for the address type
                },
                new Address
                {
                    Street = src.MoveToAddress.Street,
                    //Type = "MoveTo" // Custom label for the address type
                }
             }));

            /*------------Business Moves mapping -----------------*/
            CreateMap<Move, BusinessMoveDto>();
                //.ForMember(dest => dest.MoveFromAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveFrom")))
                //.ForMember(dest => dest.MoveToAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(a => a.Type == "MoveTo")));

            CreateMap<BusinessMoveDto, Move>()
             .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => new List<Address>
             {
                new Address
                {
                    Street = src.MoveFromAddress.Street,
                    //Type = "MoveFrom" // Custom label for the address type
                },
                new Address
                {
                    Street = src.MoveToAddress.Street,
                    //Type = "MoveTo" // Custom label for the address type
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
        }
    }
}
