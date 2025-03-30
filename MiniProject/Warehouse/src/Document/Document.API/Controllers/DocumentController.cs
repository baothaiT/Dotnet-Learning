using Document.Application.Models.Responses;
using Document.Application.UserCases.V1.Queries.Document.GetAllDocument;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Commons;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Document.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ApiResult<List<DocumentResponse>>> GetAsync()
        {
            var query = new GetAllDocumentQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        //// GET api/<DocumentController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<DocumentController>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<DocumentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<DocumentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
