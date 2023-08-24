using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAndAuthorController : ControllerBase
    {
        private readonly IBookAndAuthorService _bookAndAuthorService;

        public BookAndAuthorController(IBookAndAuthorService bookAndAuthorService)
        {
            _bookAndAuthorService = bookAndAuthorService;
        }

        [HttpGet("get-all")]
        public  IActionResult GetAll()
        {
            var result=  _bookAndAuthorService.GetListAsync( );
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getBookAndAuthorById")]
        public IActionResult Get(int id) 
        {
            var result = _bookAndAuthorService.GetByIdEntity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
