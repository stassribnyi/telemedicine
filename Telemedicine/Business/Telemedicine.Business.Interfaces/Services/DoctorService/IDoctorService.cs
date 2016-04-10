using System.Collections.Generic;
using Telemedicine.Business.Interfaces.CommonDto;

namespace Telemedicine.Business.Interfaces.Services.DoctorService
{
    public interface IDoctorService
    {
        IEnumerable<DoctorDto> GetDoctors();        
        DoctorDto GetDoctor(int id);
        DoctorDto CreateDoctor(DoctorDto doctor);
        void UpdateDoctor(DoctorDto doctor);
        void RemoveDoctor(int id);        
    }
}
