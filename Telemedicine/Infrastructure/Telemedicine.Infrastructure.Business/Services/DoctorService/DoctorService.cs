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

        public bool CkeckEmail(string email)
        {
            return email != null ? _unitOfWork.Doctors.GetAll().Any(x => x.Email.ToLower().Equals(email.ToLower())): true;
        }

        public bool CkeckLogin(string login)
        {
            return login != null ? _unitOfWork.Doctors.GetAll().Any(x => x.Login.ToLower().Equals(login.ToLower())): true;
        }

        public DoctorDto CreateDoctor(DoctorDto doctor)
        {
            var model = _doctorMapper.Map<Doctor>(doctor);
            Hospital hospital = null;
            if (doctor.Hospital != null)
            {
                hospital = _unitOfWork.Hospitals.Get(doctor.Hospital.Id);
                doctor.Hospital = null;
            }
            _unitOfWork.Doctors.Create(model);
            model.Hospital = hospital;
            _unitOfWork.Save();
            return _doctorMapper.Map<DoctorDto>(model);
        }

        public DoctorDto GetDoctor(int id)
        {
            return _doctorMapper.Map<DoctorDto>(_unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == id));
        }

        public DoctorDto GetDoctorByLogin(string login)
        {
            return _doctorMapper.Map<DoctorDto>(_unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Login == login));
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
