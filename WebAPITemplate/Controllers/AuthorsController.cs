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
        public IActionResult AddBook([FromBody] AuthorVM author)
        {
            _authorsservice.AddAuthor(author);

            return Ok();
        }

    }
}
