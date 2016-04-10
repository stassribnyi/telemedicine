using System.Web.Http;
using Telemedicine.Business.Interfaces.CommonDto;
using Telemedicine.Business.Interfaces.Services.CommentService;

namespace Telemedicine.Web.Controllers.Api
{
    public class CommentController : ApiController
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet]
        [Route("api/comment/{id}")]
        public IHttpActionResult GetComment(int id)
        {
            var comment = _commentService.GetComment(id);
            return Ok(comment);
        }        
        
        [HttpPut]
        [Route("api/comment/{id}")]
        public IHttpActionResult Put(int id, [FromBody]CommentDto comment)
        {
            _commentService.UpdateComment(comment);
            return Ok();
        }


        [HttpDelete]
        [Route("api/comment/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _commentService.RemoveComment(id);
            return Ok();
        }
    }
}
