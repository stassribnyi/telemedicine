using System.Web.Http;
using Telemedicine.Business.Interfaces.Services.HospitalService;

namespace Telemedicine.Web.Controllers.Api
{
    public class HospitalController : ApiController
    {
        private IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        [Route("api/hospital/{id?}")]
        public IHttpActionResult Get(int? id = null)
        {
            if (id.HasValue)
            {
                var hospital = _hospitalService.GetHospital(id.Value);
                return Ok(hospital);
            }
            else
            {
                var hospitals = _hospitalService.GetHospitals();
                return Ok(hospitals);
            }
        }        
    }
}
