using System.Web.Http;
using Telemedicine.Business.Interfaces.CommonDto;
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
        public IHttpActionResult GetCurrent()
        {
            var id = 3;
            var doctor = _doctorService.GetDoctor(id);
            return Ok(doctor);
        }
        

        [HttpPost]
        [Route("api/doctor/checklogin")]
        public IHttpActionResult PostCheckLogin([FromBody]StringObject login)
        {
            return Ok(new {value = _doctorService.CkeckLogin(login.Value) });
        }

        [HttpPost]
        [Route("api/doctor/checkemail")]
        public IHttpActionResult PostCheckEmail([FromBody]StringObject email)
        {
            return Ok(new { value = _doctorService.CkeckEmail(email.Value) });
        }

        [HttpPost]
        [Route("api/doctor")]
        public IHttpActionResult Post([FromBody]DoctorDto doctor)
        {
            var dto = _doctorService.CreateDoctor(doctor);
            return Ok(dto);
        }

        [HttpPut]
        [Route("api/doctor/{id}")]
        public IHttpActionResult Put(int id, [FromBody]DoctorDto doctor)
        {
            _doctorService.UpdateDoctor(doctor);
            return Ok();
        }


        [HttpDelete]
        [Route("api/doctor/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _doctorService.RemoveDoctor(id);
            return Ok();
        }
    }
}
