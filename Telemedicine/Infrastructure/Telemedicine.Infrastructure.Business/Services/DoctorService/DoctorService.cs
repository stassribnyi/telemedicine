using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Business.Interfaces.Services.DoctorService;
using Telemedicine.Common.Factories;
using Telemedicine.Domain.Interfaces.Common;
using Telemedicine.Infrastructure.Business.Common;
using Telemedicine.Domain.Core.Models;

namespace Telemedicine.Infrastructure.Business.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private IMapper _doctorMapper;
        private IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            _unitOfWork = unitOfWork;
            _doctorMapper = mapperFactory.CreateMapper<CommonProfile>().Mapper;
        }       

        public DoctorDto CreateDoctor(DoctorDto doctor)
        {
            var model = _doctorMapper.Map<Doctor>(doctor);
            _unitOfWork.Doctors.Create(model);
            _unitOfWork.Save();
            return _doctorMapper.Map<DoctorDto>(model);
        }

        public DoctorDto GetDoctor(int id)
        {
            return _doctorMapper.Map<DoctorDto>(_unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<DoctorDto> GetDoctors()
        {
            return _doctorMapper.Map<IEnumerable<DoctorDto>>(_unitOfWork.Doctors.GetAll());
        }

        public void RemoveDoctor(int id)
        {
            _unitOfWork.Doctors.Delete(id);
            _unitOfWork.Save();
        }

        public void UpdateDoctor(DoctorDto doctor)
        {
            var model = _doctorMapper.Map<Doctor>(doctor);
            _unitOfWork.Doctors.Update(model);
            _unitOfWork.Save();
        }
    }
}
