using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.AspNetCore.Mvc;

namespace WEBApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishersController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpPost("publisher-Add")]
    public IActionResult Add(CreatePublisherDTO publisher)
    {
        var result = _publisherService.CreateEntity(publisher);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpPost("publisher-Delete")]
    public IActionResult Delete(DeletePublisherDTO publisher)
    {
        var result = _publisherService.DeleteEntity(publisher);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpPost("publisher-Update")]
    public IActionResult Update(UpdatePublisherDTO publisher)
    {
        var result = _publisherService.UpdateEntity(publisher);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpGet("getById")]
    public IActionResult GetById(int id)
    {
        var result = _publisherService.GetByIdEntity(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }
    [HttpGet("publisher-GetAll")]
    public IActionResult Get()
    {

        var result = _publisherService.Get();
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
}
