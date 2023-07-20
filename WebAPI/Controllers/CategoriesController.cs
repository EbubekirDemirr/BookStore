using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.AspNetCore.Mvc;

namespace WEBApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    private readonly LibraryContext _libraryContext;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
       
    }

    [HttpPost("category-Add")]
    public IActionResult Add(CreateCategoryDTO category)
    {
        var result = _categoryService.CreateEntity(category);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
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
}
