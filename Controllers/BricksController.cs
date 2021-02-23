using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using morning_challenge_tuesday.Models;
using morning_challenge_tuesday.Services;

namespace morning_challenge_tuesday.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BricksController : ControllerBase
  {
    private readonly BricksService _service;

    public BricksController(BricksService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Brick>> GetAll()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Brick> GetOne(int id)
    {
      try
      {
        return Ok(_service.GetOne(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Brick> Create([FromBody] Brick newBrick)
    {
      try
      {
        return Ok(_service.Create(newBrick));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Brick> Edit([FromBody] Brick newBrick, int id)
    {
      try
      {
        newBrick.Id = id;
        return Ok(_service.Edit(newBrick));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Ok(_service.Delete(id));
        return Ok("Deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}