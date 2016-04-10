using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Business.Interfaces.Services.PatientService;

namespace Telemedicine.Web.Controllers.Api
{
    public class PatientController : ApiController
    {
        private IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("api/patients/{id?}")]
        public IHttpActionResult Get(int? id = null)
        {
            var patients = _patientService.GetPatients(id);
            return Ok(patients);
        }
        [HttpGet]
        [Route("api/patient/{id}")]
        public IHttpActionResult GetPatient(int id)
        {
            var patient = _patientService.GetPatient(id);
            return Ok(patient);
        }

        [HttpPost]
        [Route("api/patient")]
        public IHttpActionResult Post([FromBody]PatientDto patient)
        {
            var dto = _patientService.CreatePatient(patient);
            return Ok(dto);
        }

        [HttpPost]
        [Route("api/patient/{id}/newcomment")]
        public IHttpActionResult Post(int id, [FromBody]CommentDto comment)
        {
            var result = _patientService.AddComment(id, comment);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/patient/{id}")]
        public IHttpActionResult Put(int id, [FromBody]PatientDto patient)
        {
            _patientService.UpdatePatient(patient);
            return Ok();
        }


        [HttpDelete]
        [Route("api/patient/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _patientService.RemovePatient(id);
            return Ok();
        }
    }

}