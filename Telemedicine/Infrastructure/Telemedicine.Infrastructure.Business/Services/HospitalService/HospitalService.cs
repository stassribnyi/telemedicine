using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Business.Interfaces.Services.HospitalService;
using Telemedicine.Common.Factories;
using Telemedicine.Domain.Interfaces.Common;
using Telemedicine.Infrastructure.Business.Common;
using Telemedicine.Domain.Core.Models;

namespace Telemedicine.Infrastructure.Business.Services.HospitalService
{
    public class HospitalService : IHospitalService
    {
        private IMapper _hospitalMapper;
        private IUnitOfWork _unitOfWork;

        public HospitalService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            _unitOfWork = unitOfWork;
            _hospitalMapper = mapperFactory.CreateMapper<CommonProfile>().Mapper;
        }

        public HospitalDto CreateHospital(HospitalDto Hospital)
        {
            var model = _hospitalMapper.Map<Hospital>(Hospital);
            _unitOfWork.Hospitals.Create(model);
            _unitOfWork.Save();
            return _hospitalMapper.Map<HospitalDto>(model);
        }

        public HospitalDto GetHospital(int id)
        {
            return _hospitalMapper.Map<HospitalDto>(_unitOfWork.Hospitals.GetAll().FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<HospitalDto> GetHospitals()
        {
            return _hospitalMapper.Map<IEnumerable<HospitalDto>>(_unitOfWork.Hospitals.GetAll());
        }

        public void RemoveHospital(int id)
        {
            _unitOfWork.Hospitals.Delete(id);
            _unitOfWork.Save();
        }

        public void UpdateHospital(HospitalDto Hospital)
        {
            var model = _hospitalMapper.Map<Hospital>(Hospital);
            _unitOfWork.Hospitals.Update(model);
            _unitOfWork.Save();
        }
    }
}
