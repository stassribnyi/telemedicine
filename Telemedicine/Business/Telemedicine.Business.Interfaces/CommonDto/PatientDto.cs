using System;
using System.Collections.Generic;
using Telemedicine.Domain.Core.Models;

namespace Telemedicine.Business.Interfaces.CommonDto
{
    public class PatientDto : UserDto
    {
        public long INN { get; set; }
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
        public Guid DeviceId { get; set; }
        public ICollection<DoctorDto> Doctors { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
