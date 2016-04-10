using System;

namespace Telemedicine.Business.Interfaces.CommonDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime LastModified { get; set; }
        public DoctorDto Doctor { get; set; }
    }
}