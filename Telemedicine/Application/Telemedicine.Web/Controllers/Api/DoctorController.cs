using System.Web.Http;
using Telemedicine.Business.Interfaces.Services.DoctorService;

namespace Telemedicine.Web.Controllers.Api
{
    public class DoctorController : ApiController
    {
        private IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [Route("api/doctor/current")]
        public IHttpActionResult Get()
        {
            var id = 3;
            var doctor = _doctorService.GetDoctor(id);
            return Ok(doctor);
        }        
    }
}
