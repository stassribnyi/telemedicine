using System.Collections.Generic;
using System.Data.Entity;
using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Repositories;

namespace Telemedicine.Infrastructure.Data
{
    public class CommentRepository : ICommentRepository
    {
        private TelemedicineContext _db;

        public CommentRepository(TelemedicineContext context)
        {
            _db = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _db.Comments;
        }

        public Comment Get(int id)
        {
            return _db.Comments.Find(id);
        }

        public void Create(Comment comment)
        {
            _db.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            _db.Entry(comment).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var comment = _db.Comments.Find(id);
            if (comment != null)
                _db.Comments.Remove(comment);
        }
    }
}