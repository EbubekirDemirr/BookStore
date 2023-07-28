using Business.Abstract;
using Core.Redis;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.Models;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEBApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly ICacheService _cacheService;
    private readonly LibraryContext _libraryContext;

    public CategoriesController(ICategoryService categoryService, ICacheService cacheService, LibraryContext libraryContext)
    {
        _categoryService = categoryService;
        _cacheService = cacheService;
        _libraryContext = libraryContext;

    }


    [HttpPost("category-Delete")]
    public IActionResult Delete(DeleteCategoryDTO category)
    {
        var result = _categoryService.DeleteEntity(category);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpPost("category-Update")]
    public IActionResult Update(UpdateCategoryDTO category)
    {
        var result = _categoryService.UpdateEntity(category);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpPost("category-Create")]

    public IActionResult Create(CreateCategoryDTO category)
    {
        var result = _categoryService.CreateEntity(category);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpGet("category-GetAll")]
    public IActionResult Get()
    {

        var result = _categoryService.Get();
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
}
