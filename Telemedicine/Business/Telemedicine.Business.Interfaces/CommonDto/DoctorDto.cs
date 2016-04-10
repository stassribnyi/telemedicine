using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Business.Interfaces.CommonDto
{
    public class DoctorDto : UserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MedicalSpecialization { get; set; }
        public HospitalDto Hospital { get; set; }
    }
}
