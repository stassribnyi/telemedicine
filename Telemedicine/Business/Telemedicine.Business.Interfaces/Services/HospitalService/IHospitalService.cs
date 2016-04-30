using System.Collections.Generic;
using Telemedicine.Business.Interfaces.CommonDto;

namespace Telemedicine.Business.Interfaces.Services.HospitalService
{
    public interface IHospitalService
    {
        IEnumerable<HospitalDto> GetHospitals();
        HospitalDto GetHospital(int id);
        HospitalDto CreateHospital(HospitalDto hospital);
        void UpdateHospital(HospitalDto hospital);
        void RemoveHospital(int id);
    }
}
