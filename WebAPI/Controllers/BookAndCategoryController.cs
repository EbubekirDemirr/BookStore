using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAndCategoryController : Controller
    {
        private readonly IBookAndCategoryService _bookAndCategoryService;

        public BookAndCategoryController(IBookAndCategoryService bookAndCategoryService)
        {
            _bookAndCategoryService = bookAndCategoryService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = _bookAndCategoryService.GetListAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getBookAndCategoryById")]
        public IActionResult Get(int id)
        {
            var result = _bookAndCategoryService.GetByIdEntity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
