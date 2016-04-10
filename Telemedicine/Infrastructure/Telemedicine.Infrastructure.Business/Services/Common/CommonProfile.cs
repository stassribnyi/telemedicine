using AutoMapper;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Domain.Core.Models;

namespace Telemedicine.Infrastructure.Business.Common
{
    public class CommonProfile : Profile
    {
        protected override void Configure()
        {
            AllowNullDestinationValues = true;

            CreateMap<Patient, PatientDto>()
                .ReverseMap()
                ;

            CreateMap<Analyze, AnalyzeDto>()
                .ReverseMap()
                ;

            CreateMap<Pressure, PressureDto>()
               .ReverseMap()
               ;

            CreateMap<ECGData, ECGDataDto>()
             .ReverseMap()
             ;

            CreateMap<ECG, ECGDto>()
              .ReverseMap()
              ;                      

            CreateMap<Doctor, DoctorDto>()
                .ReverseMap()
                ;

            CreateMap<Hospital, HospitalDto>()
                .ReverseMap()
                ;

            CreateMap<Comment, CommentDto>()
                .ReverseMap()
                ;         
        }
    }
}
