using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Book.Data.DTO;
using My_Book.Data.Services;

namespace My_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        private PublisherService _service;

        public PublishersController(PublisherService service)
        {
            _service = service;
        }


        [HttpPost("Add-Publisher")]
        public async Task<ActionResult> AddPublisher([FromBody] PublisherDTO publisherDTO)
        {
            var _publisher = await _service.AddPublisher(publisherDTO);
            return Ok(_publisher);
        }


        [HttpGet("Get-PublisherBookAndAuthor/{publisherId}")]
        public async Task<ActionResult> GetAuthorWithBooks(int publisherId)
        {
            var _publisher = await _service.GetPublisherWithBookAndAuthor(publisherId);
            if (_publisher == null)
            {
                return BadRequest("Cannot found Publisher with ID");
            }
            return Ok(_publisher);
        }

    }
}
