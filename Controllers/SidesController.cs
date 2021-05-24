using System;
using System.Collections.Generic;
using burgershack.Interfaces;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SidesController : ControllerBase, ICodeWorksRestfulController<Side>
  {
    private readonly SidesService _bs;

    public SidesController(SidesService bs)
    {
      _bs = bs;
    }
    [HttpPost]
    public ActionResult<Side> Create([FromBody] Side newSide)
    {
      try
      {
        Side side = _bs.Create(newSide);
        return Ok(side);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Side> Delete(int id)
    {
      try
      {
        _bs.Delete(id);
        return Ok("Side Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
      try
      {
        IEnumerable<Side> sides = _bs.GetAll();
        return Ok(sides);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Side> GetOne(int id)
    {
      try
      {
        Side side = _bs.GetOne(id);
        return Ok(side);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public ActionResult<Side> Update(Side Data)
    {
      try
      {
        throw new System.NotImplementedException();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
