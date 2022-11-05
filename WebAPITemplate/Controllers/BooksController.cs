using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITemplate.Data.Services;
using WebAPITemplate.Data.ViewModels;

namespace WebAPITemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //inject service
        public BooksService _booksservice;

        public BooksController(BooksService booksservice)
        {
            _booksservice = booksservice;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksservice.AddBook(book);

            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksservice.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksservice.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updatedBook = _booksservice.UpdateBookById(id, book);

            return Ok(updatedBook);
        }
    }
}
