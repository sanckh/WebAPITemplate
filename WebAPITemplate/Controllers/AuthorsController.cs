using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITemplate.Data.Services;
using WebAPITemplate.Data.ViewModels;

namespace WebAPITemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //inject service
        public AuthorsService _authorsservice;
        public AuthorsController(AuthorsService authorsservice)
        {
            _authorsservice = authorsservice;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM book)
        {
            _authorsservice.AddAuthor(book);

            return Ok();
        }

    }
}
