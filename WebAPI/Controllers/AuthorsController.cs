using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("author-Add")]
        public IActionResult Add(CreateAuthorDTO author)
        {
            var result =_authorService.CreateEntity(author);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("author-Delete")]
        public IActionResult Delete(DeleteAuthorDTO author)
        {
            var result =_authorService.DeleteEntity(author);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("author-Update")]
        public IActionResult Update(UpdateAuthorDTO author)
        {
            var result = _authorService.UpdateEntity(author);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _authorService.GetByIdEntity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("author-GetAll")]
        public IActionResult Get()
        {

            var result = _authorService.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("getAuthorDetail")]
        public IActionResult GetAuthorDetail(int id)
        {
            var result = _authorService.GetAuthorDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
