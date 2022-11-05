using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITemplate.Data.Services;
using WebAPITemplate.Data.ViewModels;

namespace WebAPITemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        //inject service
        public PublishersService _publishersservice;
        public PublishersController(PublishersService publishersservice)
        {
            _publishersservice = publishersservice;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddBook([FromBody] PublisherVM publisher)
        {
            _publishersservice.AddPublisher(publisher);

            return Ok();
        }
    }
}
