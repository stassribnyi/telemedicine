using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Business.Interfaces.Services.AnalyzeService;
using Telemedicine.Common.Factories;
using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Common;
using Telemedicine.Infrastructure.Business.Common;

namespace Telemedicine.Infrastructure.Business.Services.Analyzes
{
    public class AnalyzeService : IAnalyzeService
    {
        private IMapper _analyzeMapper;
        private IUnitOfWork _unitOfWork;

        public AnalyzeService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            _unitOfWork = unitOfWork;  
            _analyzeMapper = mapperFactory.CreateMapper<CommonProfile>().Mapper;
        }

        public CommentDto AddComment(int id, CommentDto comment)
        {
            var model = _unitOfWork.Analyzes.Get(id);
            var entity = _analyzeMapper.Map<Comment>(comment);
            var doctor = _unitOfWork.Doctors.Get(comment.Doctor.Id);
            entity.Doctor = doctor;
            model.Comments.Add(entity);
            _unitOfWork.Save();
            return _analyzeMapper.Map<CommentDto>(entity);
        }

        public CommentDto AddECGComment(int id, CommentDto comment)
        {
            var model = _unitOfWork.Analyzes.Get(id);
            var entity = _analyzeMapper.Map<Comment>(comment);
            var doctor = _unitOfWork.Doctors.Get(comment.Doctor.Id);
            entity.Doctor = doctor;
            model.ECG.Comments.Add(entity);
            _unitOfWork.Save();
            return _analyzeMapper.Map<CommentDto>(entity);
        }

        public AnalyzeDto CreateAnalyze(int id, AnalyzeDto analyze)
        {
            var model = _analyzeMapper.Map<Analyze>(analyze);
            var patient = _unitOfWork.Patients.Get(id);
            patient.Analyzes.Add(model);
            _unitOfWork.Save();
            return _analyzeMapper.Map<AnalyzeDto>(model);
        }

        public AnalyzeDto GetAnalyze(int id)
        {
            return _analyzeMapper.Map<AnalyzeDto>(_unitOfWork.Analyzes.GetAll().FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<AnalyzeDto> GetAnalyzes(int? id)
        {
            return _analyzeMapper.Map<IEnumerable<AnalyzeDto>>(_unitOfWork.Analyzes.GetAll()
                .Where(x => id.HasValue ? x.Patient.Id == id.Value : true));
        }

        public void RemoveAnalyze(int id)
        {
            _unitOfWork.Analyzes.Delete(id);
            _unitOfWork.Save();
        }

        public void UpdateAnalyze(AnalyzeDto Analyze)
        {
            var model = _analyzeMapper.Map<Analyze>(Analyze);
            _unitOfWork.Analyzes.Update(model);
            _unitOfWork.Save();
        }
    }
}
