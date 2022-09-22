using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Book.Data.DTO;
using My_Book.Data.Model;
using My_Book.Data.Services;

namespace My_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService _service;

        public BooksController(BookService service)
        {
            _service = service;
        }


        [HttpGet("Get-All-Books")]
        public async Task<ActionResult> GetAllBook() => Ok(await _service.GetAllBook());


        [HttpGet("Get-Book/{Id}")]
        public async Task<ActionResult> GetOneBook(int Id)
        {
            var _book = await _service.GetOneBook(Id);
            if (_book == null)
            {
                return BadRequest("Book with Id not Found");
            }
            return Ok(_book);
        }


        [HttpPost]
        //Show the properties of BookDTO to fill by users
        public async Task<ActionResult> AddBook([FromBody] BookDTO bookDTO)
        {
            //Get the Book model from the AddBook method.
            var _book = await _service.AddBook(bookDTO);
            // calls the GetOneBook to display the newly created Book object.
            return CreatedAtAction(nameof(GetOneBook), new { id = _book.Id }, _book);
        }

        [HttpPut("Update-Book/{bookId}")]
        public async Task<ActionResult> UpdateBook(int bookId, [FromBody] BookDTO bookDTO)
        {
            //Get the Book model from the AddBook method.
            var _book = await _service.UpdateBook(bookId, bookDTO);
            if(_book != null)
            {
                // calls the GetOneBook to display the newly created Book object.
                return CreatedAtAction(nameof(GetOneBook), new { id = _book.Id }, _book);
            }
            return BadRequest("Book with Id not Found");
        }

        [HttpDelete("Delete-BookById/{bookId}")]

        public async Task<ActionResult<Book>> DeleteBook(int bookId)
        {
            var _book = await _service.DeleteBook(bookId);
            if(_book == null)
            {
                return BadRequest("Book with Id not Found");
            }
            else
            {
                return _book;
            }

           
        }
          

    }


}
