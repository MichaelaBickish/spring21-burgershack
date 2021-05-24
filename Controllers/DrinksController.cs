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
  public class DrinksController : ControllerBase, ICodeWorksRestfulController<Drink>
  {
    private readonly DrinksService _bs;

    public DrinksController(DrinksService bs)
    {
      _bs = bs;
    }
    [HttpPost]
    public ActionResult<Drink> Create([FromBody] Drink newDrink)
    {
      try
      {
        Drink drink = _bs.Create(newDrink);
        return Ok(drink);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Drink> Delete(int id)
    {
      try
      {
        _bs.Delete(id);
        return Ok("Drink Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public ActionResult<IEnumerable<Drink>> Get()
    {
      try
      {
        IEnumerable<Drink> drinks = _bs.GetAll();
        return Ok(drinks);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Drink> GetOne(int id)
    {
      try
      {
        Drink drink = _bs.GetOne(id);
        return Ok(drink);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Drink> Update([FromBody] Drink update)
    {
      try
      {
        Drink updated = _bs.Update(update);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
