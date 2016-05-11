using AutoMapper;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Security.Models;

namespace Telemedicine.Security.Common
{
    public class CommonProfile : Profile
    {
        protected override void Configure()
        {
            AllowNullDestinationValues = true;

            CreateMap<DoctorDto, ApplicationUser>()
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login))
                 .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                 .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ReverseMap()
                ;

            CreateMap<HospitalDto, Hospital>()
                .ReverseMap()
                ;                      
        }
    }
}
