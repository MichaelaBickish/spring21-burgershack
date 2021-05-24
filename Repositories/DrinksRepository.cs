using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Interfaces;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class DrinksRepository : IRepo<Drink>
  {
    private readonly IDbConnection _db;
    public DrinksRepository(IDbConnection db)
    {
      _db = db;
    }

    public Drink Create(Drink newDrink)
    {
      string sql = @"
      INSERT INTO drinks
      (name, cost, quantity, modifications)
      VALUES
      (@Name, @Cost, @Quantity, @Modifications)
      SELECT LAST_INSERT_ID()";
      newDrink.Id = _db.ExecuteScalar<int>(sql, newDrink);
      return newDrink;
    }

    internal IEnumerable<Drink> GetById()
    {
      throw new NotImplementedException();
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM drinks WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    public IEnumerable<Drink> GetAll()
    {
      string sql = "SELECT * FROM drinks";
      return _db.Query<Drink>(sql);
    }

    public Drink GetById(int id)
    {
      string sql = "SELECT * FROM drinks WHERE id = @id";
      return _db.QueryFirstOrDefault<Drink>(sql, new { id });
    }

    public bool Update(Drink original)
    {
      string sql = @"
      UPDATE drinks
      SET
       name = @Name,
       cost = @Cost,
       quantity = @Quantity,
       modification = @Modification
       WHERE id=@Id";
      int affectedRows = _db.Execute(sql, original);
      return affectedRows == 1;
    }


  }

}