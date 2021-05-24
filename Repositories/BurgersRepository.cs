using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Interfaces;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class BurgersRepository : IRepo<Burger>
  {

    private readonly IDbConnection _db;

    public BurgersRepository(IDbConnection db)
    {
      _db = db;

    }

    public Burger Create(Burger newBurger)
    {
      string sql = @"
            INSERT INTO burgers
            (name, cost, quantity, modifications, itemType)
            VALUES
            (@Name, @Cost, @Quantity, @Modifications, @ItemType)
            SELECT LAST_INSERT_ID()";
      newBurger.Id = _db.ExecuteScalar<int>(sql, newBurger);
      return newBurger;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM burgers WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    public IEnumerable<Burger> GetAll()
    {
      string sql = @"
     SELECT 
     * 
     FROM burgers";
      return _db.Query<Burger>(sql);
    }

    public Burger GetById(int id)
    {
      string sql = @"
      SELECT
      *
      FROM burgers
      WHERE id = @id";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    public bool Update(Burger original)
    {
      string sql = @"
      UPDATE burgers
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