using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Business.Interfaces.Services.PatientService;
using Telemedicine.Common.Factories;
using Telemedicine.Domain.Interfaces.Common;
using Telemedicine.Infrastructure.Business.Common;
using Telemedicine.Domain.Core.Models;

namespace Telemedicine.Infrastructure.Business.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private IMapper _patientMapper;
        private IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            _unitOfWork = unitOfWork;
            _patientMapper = mapperFactory.CreateMapper<CommonProfile>().Mapper;
        }

        public CommentDto AddComment(int id, CommentDto comment)
        {
            var model = _unitOfWork.Patients.Get(id);
            var entity = _patientMapper.Map<Comment>(comment);
            var doctor = _unitOfWork.Doctors.Get(comment.Doctor.Id);
            entity.Doctor = doctor;
            model.Comments.Add(entity);
            _unitOfWork.Save();
            return _patientMapper.Map<CommentDto>(entity);
        }

        public PatientDto CreatePatient(PatientDto patient)
        {
            var model = _patientMapper.Map<Patient>(patient);
            var doctor = _unitOfWork.Doctors.Get(patient.Doctors.LastOrDefault().Id);
            model.Doctors.Clear();
            model.Doctors.Add(doctor);
            _unitOfWork.Patients.Create(model);
            _unitOfWork.Save();
            return _patientMapper.Map<PatientDto>(model);
        }

        public PatientDto GetPatient(int id)
        {
            return _patientMapper.Map<PatientDto>(_unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<PatientDto> GetPatients(int? id)
        {
            var ss = _patientMapper.Map<IEnumerable<PatientDto>>(_unitOfWork.Patients.GetAll()
                .Where(x => id.HasValue ? x.Doctors.Any(z => z.Id == id.Value) : true));
            return ss;
        }

        public void RemovePatient(int id)
        {
            _unitOfWork.Patients.Delete(id);
            _unitOfWork.Save();
        }

        public void UpdatePatient(PatientDto patient)
        {
            var model = _patientMapper.Map<Patient>(patient);
            var oldModel = _unitOfWork.Patients.Get(patient.Id);
            var entity = _patientMapper.Map(model, oldModel);
            _unitOfWork.Patients.Update(entity);
            _unitOfWork.Save();
        }
    }
}
