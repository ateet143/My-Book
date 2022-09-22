using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Book.Data.DTO;
using My_Book.Data.Services;
using System.Net;

namespace My_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private AuthorService _service;

        public AuthorsController(AuthorService service)
        {
            _service = service;
        }


        [HttpPost("Add-Author")]
        public async Task<ActionResult> AddAuthor([FromBody] AuthorDTO authorDTO)
        {
            var _author = await _service.AddAuthor(authorDTO);
            return Ok(_author);
        }


    }
}
