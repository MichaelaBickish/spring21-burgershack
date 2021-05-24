using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class SidesService
  {
    private readonly SidesRepository _repo;
    public SidesService(SidesRepository repo)
    {
      _repo = repo;
    }
    internal Side Create(Side newSide)
    {
      Side side = _repo.Create(newSide);
      return side;
    }

    internal void Delete(int id)
    {
      GetOne(id);
      _repo.Delete(id);
    }

    internal IEnumerable<Side> GetAll()
    {
      return _repo.GetAll();
    }

    internal Side GetOne(int id)
    {
      Side side = _repo.GetById(id);
      if (side == null)
      {
        throw new Exception("Invalid Id")
      }
      return side;
    }
  }
}