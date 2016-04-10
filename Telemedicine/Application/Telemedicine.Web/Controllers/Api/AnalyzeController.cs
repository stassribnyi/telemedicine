using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Telemedicine.Business.Interfaces.Services.AnalyzeService;
using Telemedicine.Business.Interfaces.CommonDto;

namespace Telemedicine.Web.Controllers.Api
{
    public class AnalyzeController : ApiController
    {
        private IAnalyzeService _analyzeService;

        public AnalyzeController(IAnalyzeService analyzeService)
        {
            _analyzeService = analyzeService;
        }

        [HttpGet]
        [Route("api/analyzes/{id?}")]
        public IHttpActionResult Get(int? id = null)
        {
            var analyzes = _analyzeService.GetAnalyzes(id);
            return Ok(analyzes);
        }
        [HttpGet]
        [Route("api/analyze/{id}")]
        public IHttpActionResult GetAnalyze(int id)
        {
            var analyze = _analyzeService.GetAnalyze(id);
            return Ok(analyze);
        }

        [HttpPost]
        [Route("api/analyze/{patientId}/newanalyze")]
        public IHttpActionResult Post(int patientId, [FromBody]AnalyzeDto analyze)
        {
            var dto = _analyzeService.CreateAnalyze(patientId, analyze);
            return Ok(dto);
        }

        [HttpPost]
        [Route("api/analyze/{id}/newcomment")]
        public IHttpActionResult Post(int id, [FromBody]CommentDto comment)
        {
            var result = _analyzeService.AddComment(id, comment);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/analyze/ecg/{id}/newcomment")]
        public IHttpActionResult PostECGComment(int id, [FromBody]CommentDto comment)
        {
            var result = _analyzeService.AddECGComment(id, comment);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/analyze/{id}")]
        public IHttpActionResult Put(int id, [FromBody]AnalyzeDto analyze)
        {
            _analyzeService.UpdateAnalyze(analyze);
            return Ok();
        }


        [HttpDelete]
        [Route("api/analyze/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _analyzeService.RemoveAnalyze(id);
            return Ok();
        }
    }
}
