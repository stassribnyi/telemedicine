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
            CreateMap<Doctor, Doctor>()
               .ReverseMap()
               .ForMember(x=>x.Hospital, x => x.Ignore())
               .ForMember(x => x.Patients, x => x.Ignore())
               ;

            CreateMap<Patient, Patient>()
              .ReverseMap()
              .ForMember(x => x.Analyzes, x => x.Ignore())
              .ForMember(x => x.Comments, x => x.Ignore())
              .ForMember(x => x.Doctors, x => x.Ignore())
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
