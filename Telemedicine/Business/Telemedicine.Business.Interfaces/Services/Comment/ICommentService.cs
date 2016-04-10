using System.Collections.Generic;
using Telemedicine.Business.Interfaces.CommonDto;

namespace Telemedicine.Business.Interfaces.Services.CommentService
{
    public interface ICommentService
    {
        CommentDto GetComment(int id);
        void UpdateComment(CommentDto patient);
        void RemoveComment(int id);
    }
}
