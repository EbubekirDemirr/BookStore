using Business.Abstract;
using Entities.Concrete.Models.Authors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorImageController : ControllerBase
{
    private readonly IAuthorImageService _authorImageService;

    public AuthorImageController(IAuthorImageService authorImageService)
    {
        _authorImageService = authorImageService;
    }

    [HttpPost("add")]
    public IActionResult Add([FromForm] IFormFile formFile, [FromForm] CreateAuthorImageDto authorImage)
    {
        var result = _authorImageService.Add(formFile, authorImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }
}
