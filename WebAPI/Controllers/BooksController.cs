using Business.Abstract;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
    [HttpGet("book-GetAll")]
    public IActionResult Get( )
    {

        var result = _bookService.Get();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("get-list")]

    public  IActionResult GetList()
    {
        var result =  _bookService.GetListAsync();
        if(result == null)
        {
            return BadRequest();
        }
        return Ok(result);

    }

    [HttpGet("getBookByAuthorId")]
    public IActionResult GetBookByAuthorId(int id)
    {
        var result = _bookService.GetBookByAuthorId(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
       
    }

    [HttpGet("GetBookByCategoryId")]
    public IActionResult GetBookByCategoryId(int id)
    {
        var result = _bookService.GetBookByCategoryId(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();

    }
}
