using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.AspNetCore.Mvc;

namespace WEBApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }


    [HttpPost("book-Add")]
    public IActionResult Add(CreateBookDTO book)
    {         
        var result = _bookService.CreateEntity(book);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpPost("book-Delete")]
    public IActionResult Delete(DeleteBookDTO book)
    {
        var result = _bookService.DeleteEntity(book);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpPost("book-Update")]
    public IActionResult Update(UpdateBookDTO book)
    {
        var result = _bookService.UpdateEntity(book);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpGet("getById")]
    public IActionResult GetById(int id)
    {
        var result = _bookService.GetByIdEntity(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }
}
