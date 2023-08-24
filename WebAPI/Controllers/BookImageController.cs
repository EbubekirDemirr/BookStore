using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Models.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImageController : ControllerBase
    {
        private readonly IBookImageService _bookImageService;

        public BookImageController(IBookImageService bookImageService)
        {
            _bookImageService = bookImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile formFile, [FromForm] CreateBookImageDto bookImage)
        {
            var result = _bookImageService.Add(formFile, bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("get-ImageByBookId")]
        public IActionResult GetByCarId(int bookId)
        {
            var result = _bookImageService.GetByBookId(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
