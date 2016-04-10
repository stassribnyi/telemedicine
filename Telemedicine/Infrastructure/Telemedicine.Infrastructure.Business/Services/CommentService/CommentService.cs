using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Business.Interfaces.Services.CommentService;
using Telemedicine.Common.Factories;
using Telemedicine.Domain.Interfaces.Common;
using Telemedicine.Infrastructure.Business.Common;
using Telemedicine.Domain.Core.Models;

namespace Telemedicine.Infrastructure.Business.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private IMapper _commentMapper;
        private IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            _unitOfWork = unitOfWork;
            _commentMapper = mapperFactory.CreateMapper<CommonProfile>().Mapper;
        }       

        public CommentDto GetComment(int id)
        {
            return _commentMapper.Map<CommentDto>(_unitOfWork.Comments.GetAll().FirstOrDefault(x => x.Id == id));
        }       

        public void RemoveComment(int id)
        {
            _unitOfWork.Comments.Delete(id);
            _unitOfWork.Save();
        }

        public void UpdateComment(CommentDto comment)
        {
            var model = _commentMapper.Map<Comment>(comment);
            _unitOfWork.Comments.Update(model);
            _unitOfWork.Save();
        }
    }
}
