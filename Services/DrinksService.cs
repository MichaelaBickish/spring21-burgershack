using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class DrinksService
  {
    private readonly DrinksRepository _repo;
    public DrinksService(DrinksRepository repo)
    {
      _repo = repo;
    }
    internal Drink Create(Drink newDrink)
    {
      Drink drink = _repo.Create(newDrink);
      return drink;
    }

    internal void Delete(int id)
    {
      GetOne(id);
      _repo.Delete(id);
    }

    internal IEnumerable<Drink> GetAll()
    {
      return _repo.GetAll();
    }

    internal Drink GetOne(int id)
    {
      Drink drink = _repo.GetById(id);
      if (drink == null)
      {
        throw new Exception("Invalid Id");
      }
      return drink;
    }

    public Drink Update(Drink update)
    {
      Drink original = GetOne(update.Id);
      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.Cost = update.Cost > 0 ? update.Cost : original.Cost;
      original.Quantity = update.Quantity > 0 ? update.Quantity : original.Quantity;
      original.Modifications = update.Modifications.Length > 0 ? update.Modifications : original.Modifications;
      if (_repo.Update(original))
      {
        return original;
      }
      throw new Exception("Something went wrong");
    }
  }
}