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
            CreateMap<PrivateMove, PrivateMoveDto>();
            CreateMap<PrivateMoveDto, PrivateMove>()
             .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => new List<Address>
             {
                new Address
                {
                    Street = src.MoveFromAddress.Street,
                    Type = "MoveFrom" // Custom label for the address type
                },
                new Address
                {
                    Street = src.MoveToAddress.Street,
                    Type = "MoveTo" // Custom label for the address type
                }
             }));

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();
        }
    }
}
